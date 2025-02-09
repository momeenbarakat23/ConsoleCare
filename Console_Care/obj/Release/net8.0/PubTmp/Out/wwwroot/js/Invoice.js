

let itemcounter = 0;

function addinvoiceitem() {
    
    itemcounter++;
    const newItemRow = `
    <tr id="itemRow${itemcounter}">
    <td>
  <input type="text" name="number" value="${itemcounter}" class="form-control" />
</td>
<td>
  <select name="item" class="form-control" id="item" oninput="calculateTotal()"></select>
</td>
<td>
  <input type="text" name="quantity" value="1" class="form-control quantity" id="quantity" oninput="calculateTotal()" />
</td>
<td>
  <input type="text" name="price"  class="form-control price" id="price" oninput="calculateTotal()" readonly   />
</td>
<td>
  <input type="text" name="Discount" value="0" class="form-control price" id="discount" oninput="calculateTotal()" />
</td>
<td>
  <input type="text" name="TotalpriceForitem" id="totalprice" class="form-control totalprice"  readonly  />
</td>
<td>
  <button class="btn btn-danger" onclick="removeinvoiceitem(${itemcounter})">حذف</button>
</td>

    `;
    $("#invoiceitems").append(newItemRow);

    // update total amount on every item added
    /*updatetotalamount();*/
    loadMaterials();

    
}
//----------------------

function removeinvoiceitem(itemid) {
    $(`#itemRow${itemid}`).remove();
    calculateTotal();
}

function loadMaterials() {
    fetch('/json/GetMaterials')
        .then(response => response.json())
        .then(data => {
            const selectElement = document.querySelectorAll('#item');
           
             // مسح الخيارات الحالية
            for (var i = selectElement.length-1; i < selectElement.length; i++) {
                
                data.forEach(item => {
                    const option = document.createElement('option');
                    option.value = item.text;
                    option.text = item.text;
                    selectElement[i].appendChild(option); 
                    
                });
                
            }
            
        })
        .catch(error => console.error('Error fetching materials:', error));

}



//function updatetotalamount() {

//}

function calculateTotal() {
    let totalamount = 0;
    let totalamountprice = 0;
    $("tr[id^='itemRow']").each(function () {
        const row = $(this); 
        const item = row.find('#item').val(); 
        const quantity = parseFloat(row.find('#quantity').val()) || 1;
        const discount = parseFloat(row.find('#discount').val()) || 0;
        const specialDiscount = parseFloat(document.getElementById('specialDiscount').value) || 0;
        const typeofcust = document.getElementById('typeofcust').value;
        if (typeofcust === "PsCafe") {
            if (item) {
                fetch(`/json/GetPiecePriceps?name=${encodeURIComponent(item)}`)
                    .then(response => response.json())
                    .then(data => {
                        const piecePrice = parseFloat(data.price) || 0;

                        const Price = quantity * piecePrice;
                        const totalPrice = Price - discount;

                        const finalPrice = (1 - specialDiscount / 100) * totalPrice;

                        row.find('#price').val(piecePrice.toFixed(2));
                        row.find('#totalprice').val(totalPrice.toFixed(2));

                        totalamountprice += totalPrice;

                        totalamount += finalPrice;



                        document.getElementById('totalamountafterdisc').value = totalamount;
                        document.getElementById('totalamount').value = totalamountprice;

                    })
                    .catch(error => console.error('Error fetching piece price:', error));
            }
        } else {

            if (item) {
                fetch(`/json/GetPiecePricehome?name=${encodeURIComponent(item)}`)
                    .then(response => response.json())
                    .then(data => {
                        const piecePrice = parseFloat(data.price) || 0;

                        const Price = quantity * piecePrice;
                        const totalPrice = Price - discount;

                        const finalPrice = (1 - specialDiscount / 100) * totalPrice;

                        row.find('#price').val(piecePrice.toFixed(2));
                        row.find('#totalprice').val(totalPrice.toFixed(2));

                        totalamountprice += totalPrice;

                        totalamount += finalPrice;



                        document.getElementById('totalamountafterdisc').value = totalamount;
                        document.getElementById('totalamount').value = totalamountprice;

                    })
                    .catch(error => console.error('Error fetching piece price:', error));
            }
        }

    });
}


function printinvoice() {
    const cutomername = $("#CustomerName").val();
    const nameoftech = $("#nameoftech").val();
    let Date = $("#Date").val();
    const items = [];
    $("tr[id^='itemRow']").each(function () {
         const number = $(this).find("td:eq(0) input").val()
        const item = $(this).find("td:eq(1) select").val()
        const quantity = $(this).find("td:eq(2) input").val()
        const price = $(this).find("td:eq(3) input").val()
        const Discount = $(this).find("td:eq(4) input").val()
      
        const Total_Amount = $(this).find("td:eq(5) input").val()

        items.push({
            number: number,
            item: item,
            quantity: quantity,
            price: price,
            Discount: Discount,
            totalamount:Total_Amount

        })
    })
    const totalamountafterdisc = $("#totalamountafterdisc").val();
    const specialDiscount = $("#specialDiscount").val();
    const totalamount = $("#totalamount").val();
    const invoicecontent = `<html lang="ar" dir="rtl">
<head>
    <meta charset="UTF-8">
    <title>Console Care</title>
    <style>
        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }

        body {
            font-family: 'Cairo', sans-serif;
            padding: 20px;
            direction: rtl;
        }

        .container {
            margin: 0 auto;
            padding: 15px;
            max-width: 800px;
            border: 2px solid #000;
        }

        .header-logo {
            padding: 10px;
            border-bottom: 2px solid #000;
            margin-bottom: 20px;
        }

        .logo-section {
            display: flex;
            align-items: center;
            gap: 10px;
        }

        .logo {
            width: 100%;
        }

        .date {
            font-size: 14px;
            text-align: right;
            margin-top: 10px;
        }

        .client-info {
            margin: 15px 0;
            border-bottom: 2px solid #000;
            padding-bottom: 10px;
        }

        .info-row {
            display: flex;
            justify-content: space-between;
            margin: 5px 0;
        }

        .info-row span {
            font-size: 14px;
        }

        .title {
            text-align: center;
            font-weight: bold;
            margin: 15px 0;
            font-size: 16px;
        }

        table {
            width: 100%;
            border-collapse: collapse;
            margin: 20px 0;
        }

        th, td {
            border: 1px solid #000;
            padding: 8px;
            text-align: center;
        }

        th {
            background-color: #f0f8ff;
            font-weight: bold;
        }

        .total-row {
            text-align: right;
            padding: 10px;
            background-color: #f9f9f9;
            font-size: 14px;
        }

        .footer-text {
            text-align: center;
            margin: 15px 0;
            font-size: 14px;
        }

        .discount-section {
            background-color: #f0f8ff;
            padding: 10px;
            margin-top: 15px;
            border: 1px solid #000;
        }

        .discount-row {
            display: flex;
            justify-content: space-between;
            padding: 8px;
            background-color: #fff;
        }

        .discount-row span {
            font-size: 14px;
        }

        @media print {
            body {
                padding: 0;
            }

            .container {
                max-width: 100%;
                border: none;
            }
        }
    </style>
</head>
<body>
    <div class="container">
        <!-- Header -->
        <div class="header-logo">
            <div class="logo-section">
                <img class="logo" src="/img/Screenshot (2232).png" alt="Logo">
            </div>
        </div>

        <!-- Client Info -->
        <div class="client-info">
            <div class="info-row">
                <span>اسم المهندس الفني: ${nameoftech}</span>
                <span>رقم الفاتورة: 1097225901</span>
            </div>
            <div class="info-row">
                <span>اسم العميل: ${cutomername}</span>
                <span>التاريخ: ${Date}</span>
            </div>
        </div>

        <div class="title">مقدم لحضراتكم البيان الأول للصيانة</div>

        <!-- Invoice Table -->
        <table>
            <thead>
                <tr>
                  <th>ت<br>No</th>
                  <th>المواصفات<br>description</th>
                  <th>الكمية<br>QTY.</th>
                  <th>سعر الوحدة<br>Unit Price</th>
                  <th>الخصم النقدي<br>Discount</th>
                    <th>الإجمالي<br>Total amount</th>
                </tr>
            </thead>
                        <tbody>
    ${items.map((it) => `
        <tr>
            <td>${it.number}</td>
            <td>${it.item}</td>
            <td>${it.quantity}</td>
            <td>${it.price}</td>
            <td>${it.Discount}</td>
            <td>${it.totalamount}</td>
        </tr>`).join("")}
</tbody>
            <tfoot>
                <tr>
                    <td colspan="6" class="total-row">
                        <span>إجمالي المبلغ:</span>
                        <span class="total-amount">${totalamount} ج.م</span>
                    </td>
                </tr>
            </tfoot>
        </table>

        <div class="footer-text">الأسعار المرجعية لقطع الغيار شاملة لخدمة الصيانة</div>

        <div class="discount-section">
            <div class="discount-row">
                <span>قيمة الخصم</span>
                <span>${specialDiscount}%</span>
                <span>المبلغ المستحق بعد الخصم</span>
                <span>${totalamountafterdisc}</span>
            </div>
        </div>
    </div>
</body>
</html>
`;

    const printwindow = window.open("", "_blank")
    printwindow.document.write(invoicecontent)
    printwindow.document.close();
    printwindow.print();


}
