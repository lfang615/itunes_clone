
window.onload = function () {
  
    var popupOverlay = document.getElementById("bgOverlay");
    var popup = document.getElementById("popup");

    popupOverlay.onclick = function () {
      
        popupOverlay.style.display = "none";
        popup.style.display = "none";
    };

    var closeBtn = document.getElementById("btnClose");

    closeBtn.onclick = function () {

        popupOverlay.click();
    };

    var listViewItems = document.getElementsByClassName("lv_item");
    for (var i = 0; i < listViewItems.length; i++) {

        listViewItems[i].onmouseover = function () {

            this.children[4].style.display = "inline";
        };

        listViewItems[i].onmouseout = function () {

            this.children[4].style.display = "none";
        };

        listViewItems[i].children[4].children[0].onclick = function (){
                
            var popup = document.getElementById("popup");
            var lvItem = this.parentElement.parentElement;
            var popupOverlay = document.getElementById("bgOverlay");
                

            popup.style.display = "inline";
            popupOverlay.style.display = "inline";

            popup.children[0].src = lvItem.children[0].src;
            popup.children[1].textContent = lvItem.children[1].textContent;
            popup.children[2].textContent = lvItem.children[2].textContent;
            popup.children[3].textContent = lvItem.children[3].textContent;
        };

    }

    var ddlShoeSize = document.getElementById("ddlShoeSize");

    ddlShoeSize.onchange = function () {

        var value = this.value;

        for (var i = 0; i < listViewItems.length; i++) {

            if (value != " ") {

                var sizes = listViewItems[i].children[3].textContent.split(',');

                var matches = false;

                for (var z = 0; z < sizes.length; z++) {

                    if (sizes[z] == value) {
                        matches = true;
                        listViewItems[i].style.display = "inline";
                    }

                }
                if (matches == false) {
                    listViewItems[i].style.display = "none";
                }
            }
            else {
                listViewItems[i].style.display = "inline";
            }

        }

        if (value == null) {
            for (var n = 0; n < listViewItems.length; n++) {

                listViewItems[n].style.display = "inline";

            }
        }
            
    };

    
    var checkboxes = document.querySelectorAll("input[type=checkbox]");

    for (var a = 0; a < checkboxes.length; a++) {

        checkboxes[a].onclick = function () {


            var theValue = this.value;

            if (this.checked == true) {
                for (var c = 0; c < listViewItems.length; c++) {

                    var colors = listViewItems[c].children[5].textContent.split(',');
                    var matches = false;

                    for (var z = 0; z < colors.length; z++) {

                        if (colors[z] == theValue) {
                            matches = true;
                            listViewItems[c].style.display = "inline";
                        }
                        if (matches == false) {
                            listViewItems[c].style.display = "none";
                        }
                        else {
                            listViewItems[c].style.display = "inline";
                        }
                    }
                }
            }
            if (document.querySelectorAll("input[type=checkbox]:checked").length == 0) {
                
                for (var h = 0; h < listViewItems.length; h++) {

                    listViewItems[h].style.display = "inline";
                }
            }
           
        };

    }
};