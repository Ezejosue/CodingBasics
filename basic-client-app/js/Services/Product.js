const getAllProducts = () => {
  var pageNumber = $("#pageNumber").val();
  var pageSize = $("#pageSize").val();

  if (pageNumber >= 1 && pageSize >= 1) {
    $.ajax({
      url: `http://localhost:5000/Product?pageNumber=${pageNumber}&pageSize=${pageSize}`,
      type: "GET",
      dataType: "json",
      success: function (data) {
        $("#product-table tbody").empty();
        $.each(data, function (index, product) {
          $("#product-table tbody").append(`
                        <tr>
                            <td>${product.productId}</td>
                            <td>${product.name}</td>
                            <td>${product.productNumber}</td>
                            <td>${product.safetyStockLevel}</td>
                            <td>${product.reorderPoint}</td>
                        </tr>
                    `);
        });
        Swal.fire("Success", "Products loaded successfully!", "success");
      },
      error: function (xhr, status) {
        Swal.fire(
          "Error",
          "An error has occurred while trying to get the products!",
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

const getProductsByName = (productName) => {
  $.ajax({
    url: `http://localhost:5000/Product/${productName}`,
    type: "GET",
    dataType: "json",
    success: function (data) {
      $("#product-table tbody").empty();
      $.each(data, function (index, product) {
        $("#product-table tbody").append(`
                        <tr>
                            <td>${product.productId}</td>
                            <td>${product.name}</td>
                            <td>${product.productNumber}</td>
                            <td>${product.safetyStockLevel}</td>
                            <td>${product.reorderPoint}</td>
                        </tr>
                    `);
      });
      Swal.fire("Success", "Products loaded successfully!", "success");
    },
    error: function (xhr, status) {
      Swal.fire(
        "Error",
        "An error has occurred while trying to get products by name!",
        "error"
      );
    },
  });
};

const getProductsByCategory = (categoryType) => {
  $.ajax({
    url: `http://localhost:5000/Product/category/${categoryType}`,
    type: "GET",
    dataType: "json",
    success: function (data) {
      $("#product-table tbody").empty();
      $.each(data, function (index, product) {
        $("#product-table tbody").append(`
                        <tr>
                            <td>${product.productId}</td>
                            <td>${product.name}</td>
                            <td>${product.productNumber}</td>
                            <td>${product.safetyStockLevel}</td>
                            <td>${product.reorderPoint}</td>
                        </tr>
                    `);
      });
      Swal.fire("Success", "Products loaded successfully!", "success");
    },
    error: function (xhr, status) {
      Swal.fire(
        "Error",
        "An error has occurred while trying to get products by category!",
        "error"
      );
    },
  });
};
