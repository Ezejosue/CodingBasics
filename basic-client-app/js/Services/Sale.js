const getSalesOverview = () => {
  var pageNumber = $("#pageNumber").val();
  var pageSize = $("#pageSize").val();

  if (pageNumber >= 1 && pageSize >= 1) {
    $.ajax({
      url: `http://localhost:5000/Sale?pageNumber=${pageNumber}&pageSize=${pageSize}`,
      type: "GET",
      dataType: "json",
      success: function (data) {
        $("#sales-table tbody").empty();
        $.each(data, function (index, sale) {
          $("#sales-table tbody").append(`
                    <tr>
                        <td>${sale.businessEntityId}</td>
                        <td>${sale.firstName}</td>
                        <td>${sale.lastName}</td>
                        <td>${sale.jobTitle}</td>
                        <td>${sale.emailAddress}</td>
                        <td>${sale.phoneNumber}</td>
                        <td>${sale.countryRegionName}</td>
                        <td>${sale.salesYtd.toFixed(2)}</td>
                    </tr>
                `);
        });
        Swal.fire("Success", "Sales overview loaded successfully!", "success");
      },
      error: function (xhr, status) {
        Swal.fire(
          "Error",
          "An error has occurred while trying to get the sales overview!",
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

const getSalesByPerson = (salesPersonName, year) => {
  $.ajax({
    url: `http://localhost:5000/Sale/salesByPerson?salesPersonName=${salesPersonName}&year=${year}`,
    type: "GET",
    dataType: "json",
    success: function (data) {
      $("#sales-table tbody").empty();
      $.each(data, function (index, sale) {
        $("#sales-table tbody").append(`
                        <tr>
                            <td>${sale.businessEntityID}</td>
                            <td>${sale.salesPersonName}</td>
                            <td>${sale.salesOrderNumber}</td>
                            <td>${sale.territoryName}</td>
                            <td>${sale.subTotal.toFixed(2)}</td>
                            <td>${sale.totalDue.toFixed(2)}</td>
                        </tr>
                    `);
      });
      Swal.fire("Success", "Sales info loaded successfully!", "success");
    },
    error: function (xhr, status) {
      Swal.fire(
        "Error",
        "An error has occurred while trying to get sales info!",
        "error"
      );
    },
  });
};
