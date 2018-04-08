var API_HOME = "http://groupprojectmbr.azurewebsites.net/broker/";
// API_HOME = "http://localhost:5000/broker/";
$(document).ready(function () {
  $('#alert').hide();
  $('#addPage').css("display", "none");
})

$('#brokerAdminPageBtn').click(function(e){
  $('#mortgageFormPage').css("display", "none");
  $('#addPage').css("display", "flex");

})

$('#mortgageForm').submit(function (e) {
  e.preventDefault();
  e.stopPropagation();
  var f = $('#mortgageForm').serializeArray();
  var form = {};
  jQuery.each(f, function (i, v) {
    form[v.name] = v.value;
    console.log(v.name+" "+v.value);
  })
  form['employee']=null;
  form['customer']=null;
  
  var xttp = new XMLHttpRequest();
  var url = API_HOME + "applyformortgage";
  console.log(url);
  xttp.open("PUT", url, true);
  xttp.onreadystatechange = function () {
    if (xttp.readyState == XMLHttpRequest.DONE) {
      console.log("res: "+res);
      var res = JSON.parse(xttp.response);
      if (res.hasOwnProperty("error")) {
        dangerAlert("Could not submit mortgage form.")
      } else {
        console.log(res)
        successAlert("Your application has been submitted. Your mortgage id is: " + res['id']+ ". We still need information from your employer and insurance company. Please get them to forward them over.");
      }
    } else if (xttp.readyState == XMLHttpRequest.UNSENT) {
      dangerAlert("Could not delete image for some reason.")
    }
  }
  xttp.setRequestHeader("Content-Type", "application/json");
  console.log(JSON.stringify(form));
  xttp.send(JSON.stringify(form));
})

$('#checkApplicationForm').submit(function(e){
  e.preventDefault();
  e.stopPropagation();
  
  var xttp = new XMLHttpRequest();
  var url = API_HOME + "getapplication/"+$('#inputApplicationId').val();
  xttp.open("GET",url,true);
  xttp.onreadystatechange = function () {
    if (xttp.readyState == XMLHttpRequest.DONE) {
      var res = JSON.parse(xttp.response);
      if (res.hasOwnProperty("error")) {
        dangerAlert("Could not find mortgage application.")
      } else {
        console.log(res)
        if(res['employerApproved']==false || res['insuranceApproved']==null){
          dangerAlert("Your application has not been accepted.")
        }
        else{
          successAlert("Your application has been successfully accepted.")
        }
      }
    } else if (xttp.readyState == XMLHttpRequest.UNSENT) {
      dangerAlert("Could not delete image for some reason.")
    }
  }
  xttp.send();
})
// $('#addEmployerForm').submit(function(e){
//   e.preventDefault();
//   e.stopPropagation();
//   var xttp = new XMLHttpRequest();
//   var url = API_HOME + "addEmployer/"+$('addEmployerInputName').val();
//   xttp.open("PUT", url, true);
//   xttp.onreadystatechange = function () {
//     if (xttp.readyState == XMLHttpRequest.DONE) {
//       var res = JSON.parse(xttp.response);
//       if (res.hasOwnProperty("error")) {
//         dangerAlert("Could not add employer.")
//       } else {
//         successAlert("The employer was added successfully.");
//       }
//     } else if (xttp.readyState == XMLHttpRequest.UNSENT) {
//       dangerAlert("Could not add employer.")
//     }
//   }
//   xttp.send()
// })

// $('#addInsuranceForm').submit(function(e){
//   e.preventDefault();
//   e.stopPropagation();
//   var xttp = new XMLHttpRequest();
//   var url = API_HOME + "addInsurance/"+$('addInsuranceInputName').val();
//   xttp.open("PUT", url, true);
//   xttp.onreadystatechange = function () {
//     if (xttp.readyState == XMLHttpRequest.DONE) {
//       var res = JSON.parse(xttp.response);
//       if (res.hasOwnProperty("error")) {
//         dangerAlert("Could not add insurance company.")
//       } else {
//         successAlert("The insurance company was added successfully.");
//       }
//     } else if (xttp.readyState == XMLHttpRequest.UNSENT) {
//       dangerAlert("Could not add insurance company.")
//     }
//   }
//   xttp.send()
// })

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
