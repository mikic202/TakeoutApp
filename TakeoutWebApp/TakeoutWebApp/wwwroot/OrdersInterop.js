﻿(function () {
    window.OrdersInterop = {
        refreshOrdersData: () => {
            setInterval(() => {
                document.getElementById("btnGetOrdersData").click();
                //console.log("HHHHHHHHH");
            }, 10000);
        }
    };
})();