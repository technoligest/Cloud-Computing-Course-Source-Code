var API_HOME = "http://localhost:5000/insurance/";

function showform(customer) {
  console.log(customer)
  $('#brokerFormPage').css("display", "flex");
  $('#brokerPolicyName').val(customer['id']);
  $('#brokerPolicyValue').val(customer['value']);
  $('#brokerCustomerName').val(customer['name']);

  
}
$(document).ready(function () {
  $('#alert').hide();
  $('#addEmployeePage').css("display", "none");
  $('#brokerFormPage').css("display", "none");
  $('#addEmployeeBtn').click(function (e) {
    $('#addEmployeePage').css("display", "flex");
    $('#brokerFormPage').css("display", "none");
  })
})
$('#signinForm').submit(function (e) {
  e.preventDefault();
  e.stopPropagation();
  var xttp = new XMLHttpRequest();
  var url = API_HOME + "signin/" + $('#signinid').val();
  console.log(url);
  xttp.open("GET", url, true);
  xttp.onreadystatechange = function () {
    if (xttp.readyState == XMLHttpRequest.DONE) {
      var res = JSON.parse(xttp.response);
      if (res.hasOwnProperty("error")) {
        dangerAlert("Could not sign in. Check username.")
      } else {
        successAlert("Welcome! You're signed in.");
        $('#signinForm').css("display", "none");
        $('#addEmployeePage').css("display", "none");
        showform(res);
      }
    } else {
      dangerAlert("Could sign you in for some reason.")
    }
  }
  xttp.send();
})


$('#addInsuranceForm').submit(function (e) {
  e.preventDefault();
  e.stopPropagation();

  var f = $('#addInsuranceForm').serializeArray();
  var form = {};
  jQuery.each(f, function (i, v) {
    form[v.name] = v.value;
  })

  var xttp = new XMLHttpRequest();
  var url = API_HOME + "addcustomer";
  console.log(url);
  xttp.open("PUT", url, true);
  xttp.onreadystatechange = function () {
    if (xttp.readyState == XMLHttpRequest.DONE) {
      console.log(xttp.response)
      var res = JSON.parse(xttp.response);
      if (res.hasOwnProperty("error")) {
        dangerAlert("Could not add the insurance customer. Server returned error.")
      } else {
        successAlert("The company was added.");
      }
    } else {
      dangerAlert("Oops. Could not add employee.")
    }
  }
  xttp.setRequestHeader("Content-Type", "application/json");
  xttp.send(JSON.stringify(form));

})

$('#brokerForm').submit(function (e) {
  e.preventDefault();
  e.stopPropagation();

  var xttp = new XMLHttpRequest();
  var url = API_HOME + "agree/" + $('#inputBrokerID').val();;
  xttp.open("GET", url, true);
  xttp.onreadystatechange = function () {
    if (xttp.readyState == XMLHttpRequest.DONE) {
      console.log(xttp.response)
      var res = JSON.parse(xttp.response);
      if (res.hasOwnProperty("error")) {
        dangerAlert("Could not add the insurance. Server returned error.")
      } else {
        successAlert("The employer was successfully added to the application.");
      }
    } else {
      dangerAlert("Oops. Could not add employee.")
    }
  }
  xttp.setRequestHeader("Content-Type", "application/json");
  xttp.send();
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


















/*
function validInput() {
  var pswd = $("inputPassword").value();
  var validPassword = pswd.length >= 8 &&
    pswd.match(/[a-z]/) &&
    pswd.match(/[A-Z]/) &&
    pswd.match(/\d/) &&
    pswd.match(/[^a-zA-Z0-9\-\/]/);
  if (pswd != $("inputConfirmPassword").value() || !validPassword) {
    return false;
  }
  return true;
}
*/