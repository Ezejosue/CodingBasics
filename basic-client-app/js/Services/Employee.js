const getAllEmployees = () => {
  var pageNumber = $("#pageNumber").val();
  var pageSize = $("#pageSize").val();

  if (pageNumber >= 1 && pageSize >= 1) {
    $.ajax({
      url: `http://localhost:5000/Person?pageNumber=${pageNumber}&pageSize=${pageSize}`,
      type: "GET",
      dataType: "json",
      success: function (data) {
        $("#people-table tbody").empty();
        $.each(data, function (index, person) {
          $("#people-table tbody").append(`
                        <tr>
                            <th scope="row">${person.businessEntityId}</th>
                            <td>${person.firstName}</td>
                            <td>${person.lastName}</td>
                            <td>${person.jobTitle}</td>
                            <td>${person.phoneNumber}</td>
                            <td>${person.city}</td>
                            <td>${person.stateProvinceName}</td>
                            <td>${person.countryRegionName}</td>
                        </tr>
                    `);
        });
        Swal.fire("Success", "Employees loaded successfully!", "success");
      },
      error: function (xhr, status) {
        Swal.fire(
          "Error",
          "An error has occurred while trying to get the employees!",
          "error"
        );
      },
    });
  } else {
    Swal.fire(
      "Warning",
      "You must enter valid values for page number and page size",
      "warning"
    );
  }
};

const getPersonsByFirstName = (firstName) => {
  $.ajax({
    url: `http://localhost:5000/Person/${firstName}`,
    type: "GET",
    dataType: "json",
    success: function (data) {
      $("#people-table tbody").empty();
      $.each(data, function (index, person) {
        $("#people-table tbody").append(`
                        <tr>
                            <th scope="row">${person.businessEntityID}</th>
                            <td>${person.employeeName}</td>
                            <td>${person.personType}</td>
                            <td>${person.jobTitle}</td>
                            <td>${person.gender}</td>
                            <td>${person.maritalStatus}</td>
                            <td>${person.dateOfBirth}</td>
                            <td>${person.hireDate}</td>
                            <td>${person.vacationHours}</td>
                        </tr>
                    `);
      });
      Swal.fire("Success", "Persons loaded successfully!", "success");
    },
    error: function (xhr, status) {
      Swal.fire(
        "Error",
        "An error has occurred while trying to get persons by first name!",
        "error"
      );
    },
  });
};

const getPersonsByType = (personType) => {
  $.ajax({
    url: `http://localhost:5000/Person/personType/${personType}`,
    type: "GET",
    dataType: "json",
    success: function (data) {
      $("#people-table tbody").empty();
      $.each(data, function (index, person) {
        $("#people-table tbody").append(`
                        <tr>
                            <th scope="row">${person.businessEntityID}</th>
                            <td>${person.employeeName}</td>
                            <td>${person.personType}</td>
                            <td>${person.jobTitle}</td>
                            <td>${person.gender}</td>
                            <td>${person.maritalStatus}</td>
                            <td>${person.dateOfBirth}</td>
                            <td>${person.hireDate}</td>
                            <td>${person.vacationHours}</td>
                        </tr>
                    `);
      });
      Swal.fire("Success", "Persons loaded successfully!", "success");
    },
    error: function (xhr, status) {
      Swal.fire(
        "Error",
        "An error has occurred while trying to get persons by type!",
        "error"
      );
    },
  });
};

const getPersonsByNameAndType = (firstName, personType) => {
  $.ajax({
    url: `http://localhost:5000/Person/personTypeAndName?firstName=${firstName}&personType=${personType}`,
    type: "GET",
    dataType: "json",
    success: function (data) {
      $("#people-table tbody").empty();
      $.each(data, function (index, person) {
        $("#people-table tbody").append(`
                        <tr>
                            <th scope="row">${person.businessEntityID}</th>
                            <td>${person.employeeName}</td>
                            <td>${person.personType}</td>
                            <td>${person.jobTitle}</td>
                            <td>${person.gender}</td>
                            <td>${person.maritalStatus}</td>
                            <td>${person.dateOfBirth}</td>
                            <td>${person.hireDate}</td>
                            <td>${person.vacationHours}</td>
                        </tr>
                    `);
      });
      Swal.fire("Success", "Persons loaded successfully!", "success");
    },
    error: function (xhr, status) {
      Swal.fire(
        "Error",
        "An error has occurred while trying to get persons by name and type!",
        "error"
      );
    },
  });
};
