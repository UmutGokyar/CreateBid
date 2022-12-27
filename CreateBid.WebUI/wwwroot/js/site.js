

        var UISelectors = {
            offerCreateTable: "#offerCreateTable",
            offerItemList: "#offerItemList",
            offerItems: "#offerItemList tr",
            totalOfferValue: "#totalOfferValue",
            tax: "#tax",
            taxedTotal: "#taxedTotal",
        };


        document
            .querySelector(UISelectors.offerCreateTable)
            .addEventListener("change", calculateEvent);
        document
            .querySelector(UISelectors.offerCreateTable)
            .addEventListener("keyup", calculateEvent);
document
    .querySelector(UISelectors.offerItemList)
    .addEventListener("click", deleteRowSubmit);


           function deleteRowSubmit(e) {
               var rows = document.querySelectorAll(UISelectors.offerItems).length;
               console.log(e.target);
               if (e.target.classList.contains("delete-row") && rows > 1)
                       {

                var a = UISelectors.offerItems.length;
                console.log(a);

                deleteRowOfferList(e.target.parentNode.parentNode);
               } else if (e.target.classList.contains("delete-row")) {
                   window.alert("There must be at least one line !");
               }
                
            }
        

        function deleteRowOfferList(tr) {
            tr.remove();
            calculateTotals();
        }

        function calculateEvent(e) {
            if (e.target.classList.contains("form-control")) {
                calculateTotal(e.target);

                calculateTotals();
                e.preventDefault();
            };
        }
        //For The Row Total
        function calculateTotal(target) {
            var row = target.parentElement.parentNode;
            var quantity = row.children[1].children[0].value;
            var discount = row.children[2].children[0].value;
            var price = row.children[3].children[0].value;
            var total = row.children[4].children[0];
            total.value = ((quantity * price) - ((quantity * price) * (discount / 100))).toFixed(2);

        }
        //For The Bottom Total
        function calculateTotals() {
            const rows = document.querySelectorAll(UISelectors.offerItems);
            let totalValue = 0;
            rows.forEach(function (row) {
                totalValue += Number(row.children[4].children[0].value);
            });
            let tax = (totalValue * 0.18).toFixed(2);
            let totalWithTax = Number(totalValue) + Number(tax);
            document.querySelector(
                UISelectors.totalOfferValue
            ).innerHTML = `${totalValue.toFixed(2)} <i class="fa-solid fa-turkish-lira-sign small"> </i>`;
            document.querySelector(UISelectors.tax).innerHTML = `${tax} <i class="fa-solid fa-turkish-lira-sign small"> </i>`;
            document.querySelector(UISelectors.taxedTotal).innerHTML = `${totalWithTax.toFixed(2)} <i class="fa-solid fa-turkish-lira-sign small"> </i>`;
        }
        //Row Clone Process
        $(document).on('click', '#addRowButton', function () {

            var table = $('#offerCreateTable'),
                lastRow = table.find('tbody tr:last-child'),
                rowClone = lastRow.clone();

            var input = rowClone.find("input");
            input.val("");
      

            table.find('tbody').append(rowClone);
        });
        //Get Product Information
        $(function () {
            $("#offerCreateTable").change(function (event) {
                if (event.target.classList.contains("inputValue")) {
                    var priceInput = event.target.parentNode.nextElementSibling.nextElementSibling.nextElementSibling.children[0].value;
                    /* var id = $(".inputValue").val();*/
                    var id = event.target.value;
                    $.ajax({
                        url: '/Offer/GetPrice/' + id,
                        type: 'POST',
                        datatype: 'double?',
                        success: function (price) {
                            event.target.parentNode.nextElementSibling.nextElementSibling.nextElementSibling.children[0].value = price;
                        }
                    })
                }
            })
        })



