//CONSTANTS
var CLOUD_NAME = 'technoligest';
var UPLOAD_PRESET = 'n9nafguz';

var resourceType = 'image';
var properFormats = ["png", "jpg", "bmp"];
var generalTagName = 'all';

var API_HOME = "http://todolist2018.azurewebsites.net/v1/";

//We add submit listeners to all the forms here.
$(document).ready(function () {
  $('#alert').hide();
  $("#newStudent").submit(function (e) {
    e.preventDefault();
    addStudent($("#newNickname").val(), $('#newID').val());
  });
  $("#addPicture").submit(function (e) {
    e.preventDefault();
    var file = document.getElementById("pictureInput").files[0];
    var studentid = $("#pictureInputStudentId").val();
    if (allowedFileExtension(file.name)) {
      uploadImage(file, studentid);
    } else {
      dangerAlert("Invalid file extension. File not sent.");
    }
  });
  $("#deleteStudentForm").submit(function (e) {
    e.preventDefault();
    console.log("Deleting student." + $("#deleteID").val());
    delStudent($("#deleteID").val());
  })
  $("#uploadPicWithURLForm").submit(function (e) {
    e.preventDefault();
    var url = $("#uploadPicWithURL").val();
    var id = $("#pictureURLInputStudentId").val()
    if (url == "") {
      dangerAlert("Input a url to upload.");
    } else {
      uploadImage(url,id)
    }
  })
  if ($(document).attr('location').toString().replace(/^.*[\\\/]/, '') == "index.html") {
    listStudents();
  }
})

//Add student to the database with the given name and id
function addStudent(nickname, studentID) {
  if (nickname == null || nickname == "") {
    dangerAlert("You have to input a student name. Nobody was added.");
    return false;
  } else if (studentID == null || studentID.length != 3) {
    dangerAlert("You have to input a valid student ID. Nobody was added.");
    return false;
  }
  var xttp = new XMLHttpRequest();
  xttp.onreadystatechange = function () {
    if (xttp.readyState == XMLHttpRequest.DONE) {
      var res = JSON.parse(xttp.response);
      if (res.hasOwnProperty('error')) {
        warningAlert("Error: " + res['error']);
        console.log(xttp.response)
      } else {
        successAlert("The student has been added successfully.")
      }
    } else if (xttp.readyState == XMLHttpRequest.UNSENT) {
      dangerAlert("Could not upload image.")
    }
  }
  var url = API_HOME + "create";
  xttp.open("PUT", url, true);
  xttp.setRequestHeader("Content-Type", "application/json");
  xttp.send(JSON.stringify({
    'Nickname': nickname,
    'StudentId': studentID
  }));
  return true;
}


function uploadImageToAzure(picURL, studentID, imageId) {
  xttp = new XMLHttpRequest();
  url = API_HOME + "addpic";
  xttp.open("PUT", url, true);
  var form = new FormData();
  xttp.onreadystatechange = function () {
    if (xttp.readyState == XMLHttpRequest.DONE) {
      console.log(xttp.response);
      if (xttp.response == "Student not found. Unknown StudentId.") {
        dangerAlert("Could not upload image for an unknown user.")
        delImageFromCloudinary(imageId);
      } else {
        successAlert("Image has been successfully uploaded.")
      }
    } else if (xttp.readyState == XMLHttpRequest.UNSENT) {
      dangerAlert("Could not upload image.")
    }
  }

  form.append('URL', picURL);
  form.append('StudentId', studentID);
  convertedJSON = {};
  form.forEach(function (value, key) {
    convertedJSON[key] = value;
  });
  xttp.setRequestHeader("Content-Type", "application/json");
  xttp.send(JSON.stringify(convertedJSON));
}

function uploadImage(file, studentID) {
  var xttp = new XMLHttpRequest();
  xttp.onreadystatechange = function () {
    if (xttp.readyState == XMLHttpRequest.DONE) {
      console.log(xttp.response)
      var res = JSON.parse(xttp.response);
      if (res.hasOwnProperty("error")) {
        dangerAlert("Could not upload image.")
      } else {
        localStorage.setItem(res['public_id'], res['delete_token']);
        uploadImageToAzure(res['url'], studentID, res['public_id']);
      }
    } else if (xttp.readyState == XMLHttpRequest.UNSENT) {
      dangerAlert("Could not upload image.")
    }
  }
  var url = "https://api.cloudinary.com/v1_1/" + CLOUD_NAME + "/" + resourceType + "/upload";
  xttp.open("POST", url, true);
  var form = new FormData();
  form.append('upload_preset', UPLOAD_PRESET);
  form.append('file', file);
  form.append('tags', generalTagName);
  xttp.send(form);
}

//Deletes an image given an id
//NOTE: Images can only be deleted within 5 min of being uploaded and on the same machine.
//ALSO: It takes about a minute for the image to actually get deleted from the server.
function delImageFromCloudinary(id) {
  var xttp = new XMLHttpRequest();
  var url = "https://api.cloudinary.com/v1_1/technoligest/delete_by_token";
  xttp.open("POST", url, true);
  var form = new FormData();
  form.append('token', localStorage.getItem(id));
  xttp.send(form);
  xttp.onreadystatechange = function () {
    if (xttp.readyState == XMLHttpRequest.DONE) {
      var res = JSON.parse(xttp.response);
      if (res.hasOwnProperty("error")) {
        dangerAlert("Could not delete image for some reason.")
      } else {
        successAlert("The image has been deleted.");
      }
    } else if (xttp.readyState == XMLHttpRequest.UNSENT) {
      dangerAlert("Could not delete image for some reason.")
    }
  }
}


//Adds the student information on the page
function viewStudent(id) {
  $("#peopleTable").hide();
  xttp = new XMLHttpRequest();
  url = API_HOME + "get/" + id;
  xttp.open("GET", url, true);
  var result = "ERROR"
  xttp.onreadystatechange = function () {
    if (xttp.readyState == XMLHttpRequest.DONE) {
      var name = JSON.parse(xttp.response)['nickname'];
      var area = $("#studentArea")
      area.append(`<div class="jumbotron jumbotron-fluid">
  <div class="container">
    <h1 class="display-4">` + name + `</h1>
    <p class="lead">ID: ` + id + `</p>
  </div>
</div>`);
      area.append("<br/>");
      populateStudentPictures(id);
    } else if (xttp.readyState == XMLHttpRequest.UNSENT) {
      dangerAlert("Could not upload image.")
    }
  }
  xttp.send();
}


// Adds all the students to the page
function listStudents() {
  var addStudent = function (element) {
    $("#peopleTable > tbody:last-child").append(
      `<tr>
        <th scope="row">` + element['studentId'] +
      `</th>
        <td>` + element['nickname'] + `</td>
        <td><button class="btn btn-danger" onclick="delStudent('` + element['studentId'] + `')">Delete student</button></td>
        <td><button class="btn btn-primary" onclick="viewStudent('` + element['studentId'] + `')">View student</button></td>
      </tr>`
    );
  }
  xttp = new XMLHttpRequest();
  url = API_HOME + "all";
  xttp.open("GET", url, true);
  xttp.onreadystatechange = function () {
    if (xttp.readyState == XMLHttpRequest.DONE) {
      console.log(xttp.response);
      JSON.parse(xttp.response)['students'].forEach(addStudent);
    } else if (xttp.readyState == XMLHttpRequest.UNSENT) {
      dangerAlert("Could not upload image.")
    }
  }
  xttp.send();
}

//Prints all the pictures
function showStudentPictures(pics) {
  if (pics.length < 1) {
    return;
  }
  pics.map(function (pic) {
    if (pic != null && pic != "") {
      $("#images").append(
        `<img src=` + pic + ` class= "img-fluid" style="max-height:90%; max-width:80%;"><br/>`
      )
    }
  });
}

function populateStudentPictures(id) {
  xttp = new XMLHttpRequest();
  url = API_HOME + "getpics/" + id;
  xttp.open("GET", url, true);
  xttp.onreadystatechange = function () {
    if (xttp.readyState == XMLHttpRequest.DONE) {
      var arr = xttp.response.substring(1, xttp.response.length - 1).split(",");
      showStudentPictures(arr)
    } else if (xttp.readyState == XMLHttpRequest.UNSENT) {
      dangerAlert("Could not open student's images.")
    }
  }
  xttp.send();
}

function parseURLToID(url){
  return url.replace(/^.*[\\\/]/, '').split('.')[0];
}

function delStudent(id) {
  
  xttp2 = new XMLHttpRequest();
  url = API_HOME + "delete/" + id;
  xttp2.open("DELETE", url, true);
  xttp2.onreadystatechange = function () {
    if (xttp2.readyState == XMLHttpRequest.DONE) {
      console.log(xttp2.response);
      var res = JSON.parse(xttp2.response)['deleted'];
      warningAlert(res['Students'] + " student(s) and " + res['Pics'].length + " pictures have been deleted. ")
      res['PicURLs'].forEach(function(item){
        delImageFromCloudinary(parseURLToID(item));
      });
    } else if (xttp2.readyState == XMLHttpRequest.UNSENT) {
      dangerAlert("Could not open student's images.")
    }
  }
  xttp2.send()
}









/*
 * Helpers
 * 
 */

//Specifies the allowed extensions of files to upload
function allowedFileExtension(name) {
  return /\.(jpe?g|png|bmp)$/i.test(name);
}

function warningAlert(message) {
  $('#alert').hide();
  $('#alert').attr("class", "alert alert-warning alert-dismissible fade show");
  $('#alertMessage').html(message);
  $('#alert').show();
}

function successAlert(message) {
  $('#alert').hide();
  $('#alert').attr("class", "alert alert-success alert-dismissible fade show");
  $('#alertMessage').html(message);
  $('#alert').show();
}

function dangerAlert(message) {
  $('#alert').hide();
  $('#alert').attr("class", "alert alert-danger alert-dismissible fade show");
  $('#alertMessage').html(message);
  $('#alert').show();
}