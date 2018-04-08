var API_HOME = "http://groupprojectmbr.azurewebsites.net/realestate/";
// API_HOME = "http://localhost:5000/employer/";
function showform(realEstateBroker) {
  $('#realEstateBrokerFormPage').css("display", "flex");
  console.log(realEstateBroker);
  $('#inputMortId').val(realEstateBroker['MortId']);
  $('#inputMLS_Id').val(realEstateBroker['MLS_Id']);
}
$(document).ready(function () {
  $('#alert').hide();
  $('#aRealEstateBrokerPage').css("display", "none");
  $('#aRealEstateBrokerBtn').click()
})

$('#realEstateBrokerForm').submit(function (e) {
  e.preventDefault();
  e.stopPropagation();

  var f = $('#realEstateBrokerForm').serializeArray();
  var form = {};
  jQuery.each(f, function (i, v) {
    form[v.name] = v.value;
  })
  console.log("***");
  console.log(f);
  var xttp = new XMLHttpRequest();
  var url = API_HOME + "applyforappraisal";
  console.log(form);
  console.log(url);
  xttp.open("PUT", url, true);
  xttp.onreadystatechange = function () {
    if (xttp.readyState == XMLHttpRequest.DONE) {
      console.log(xttp.response)
      var res = JSON.parse(xttp.response);
      if (res.hasOwnProperty("error")) {
        dangerAlert("Could not contact real estate broker. Server returned error.")
      } else {
        successAlert("Information submitted to real estate broker.");
        $('#realEstateBrokerPage').css("display", "none");
        $('#realEstateBrokerForm').trigger('reset');
      }
    } else {
      dangerAlert("Oops. Could not contact real estate broker.")
    }
  }
  xttp.setRequestHeader("Content-Type", "application/json");
  console.log("yes");
  console.log(JSON.stringify(form));
  xttp.send(JSON.stringify(form));

})

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

function toJSON(formData) {
  var object = {};
  formData.forEach(function (value, key) {
    object[key] = value;
  });
  return object;

}