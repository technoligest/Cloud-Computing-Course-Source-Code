using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using A3API.Models;
using Newtonsoft.Json.Linq;
namespace A3API.Controllers
{
    [Route("v1")]
    public class StudentControler : Controller
    {
        private readonly StudentContext _context;
        public StudentControler(StudentContext context)
        {
            _context = context;
        }

        [HttpGet("get/{id}", Name = "GetStudent")]
        public IActionResult GetStudent(string id)
        {
            var stu = _context.Students.FirstOrDefault(t => t.StudentId == id);
            if (stu == null)
            {
                return NotFound();
            }

            return new ObjectResult(stu);
        }

        //Add a student object
        [HttpPut("create")]
        public IActionResult Put([FromBody]Student stu)
        {
            if (stu == null)
            {
                return BadRequest();
            }
            else if (stu.Nickname == null || stu.StudentId == null)
            {
                return BadRequest();
            }
            Console.WriteLine(stu.StudentId);
            var found = _context.Students.FirstOrDefault(st => st.StudentId == stu.StudentId);
            if(found!=null){
                dynamic result = new JObject();
                result.error = "Student already found. Did not create a new one.";
                return new ObjectResult(result);
            }
            _context.Students.Add(stu);
            _context.SaveChanges();
            return CreatedAtRoute("GetStudent", new { id = stu.ID }, stu);
        }
        public class PutPicClass
        {
            public string StudentId;
            public string URL;
        }
        [HttpPut("addpic")]
        public IActionResult PutPic([FromBody] PutPicClass s)
        {
            if (s == null)
            {
                return BadRequest();
            }
            var stu = _context.Students.FirstOrDefault(t => t.StudentId == s.StudentId);
            if (stu == null)
            {
                return new ObjectResult("Student not found. Unknown StudentId.");
            }
            var pic = new Picture(s.StudentId, s.URL);
            _context.Pictures.Add(pic);
            _context.SaveChanges();
            return new ObjectResult(pic);
        }
        [HttpGet("getpics/{stuId}")]
        public IEnumerable<string> GetPics(string stuId)
        {
            var pics = _context.Pictures.Where(ele => ele.StudentId == stuId).ToList();
            var result = new List<string>();
            foreach (Picture pic in pics)
            {
                result.Add(pic.URL);
            }
            return result;
        }
        public class Lists
        {
            public Lists(List<Picture> pics, List<Student> stus)
            {
                Pictures = pics;
                Students = stus;
            }
            public List<Picture> Pictures { get; set; }
            public List<Student> Students { get; set; }
        }
        [HttpGet("all")]
        public IActionResult getAll()
        {
            return new ObjectResult(new Lists(_context.Pictures.ToList(), _context.Students.ToList()));
        }

        [HttpDelete("delete/{studentId}")]
        public IActionResult delete(string studentId)
        {
            if (studentId == null)
            {
                return BadRequest();
            }
            var students = _context.Students.Where(stu => stu.StudentId == studentId).ToList();
            var numStudents = students.Count();
            foreach (Student stu in students)
            {
                _context.Students.Remove(stu);
            }
            var pics = _context.Pictures.Where(p => p.StudentId == studentId).ToList();
            var numPics = pics.Count();
            var urls = new List<string>();
            foreach (Picture pic in pics)
            {   
                urls.Add(pic.URL);
                _context.Pictures.Remove(pic);
            }

            _context.SaveChanges();
            dynamic vals = new JObject();
            dynamic nums = new JObject();
            nums.PicURLs = new JArray(urls);
            nums.Students = numStudents;
            nums.Pics = numPics;
            vals.deleted = nums;
            return new ObjectResult(vals);
        }
    }
}
