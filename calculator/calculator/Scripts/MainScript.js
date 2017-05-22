function numberClick() {
    txtInput.value = txtInput.value == '0' ?
            this.innerText : txtInput.value + this.innerText;
}

function plusClick() {
    if (txtResult.value == 0) {
        txtResult.value = Number(txtInput.value);
    }
    else {
        //txtResult.value = Number(txtResult.value) + Number(txtInput.value);
        txtResult = txtResult + '+';
    }

    clearEntry();

}

function minusClick() {
    txtResult.value = Number(txtResult.value) - Number(txtInput.value);
    clearEntry();
}

function multiplyClick() {
    if (txtResult.value == 0) {
        txtResult.value = Number(txtResult).value + Number(txtInput.value);
    }
    else {
        txtResult.value = Number(txtResult.value) * Number(txtInput.value);
    }
  
    clearEntry();
}

function divideClick() {
    if (Number(txtResult.value) == 0) {
        txtResult.value = Number(txtResult).value + Number(txtInput.value);
    }
    else {
        txtResult.value = Number(txtResult.value) / Number(txtInput.value);
    }
   
    clearEntry();
}

function equalsClick() {
  var result = String(txtResult) + String(txtInput);
  txtResult.value = eval(result);
}



var txtInput = 0;
var txtResult = 0;



function clearEntry() {
    txtInput.value = '0';
}

function clear() {
    txtInput.value = '0';
    txtResult.value = '0';
}

function initialize() {
    for (var i = 0; i < 10; i++) {
        document.getElementById('btn' + i).addEventListener('click', numberClick, false);
    }
    txtInput = document.getElementById('txtInput');
    txtResult = document.getElementById('txtResult');

    document.getElementById('btnPlus').addEventListener('click', plusClick, false);
    document.getElementById('btnMinus').addEventListener('click', minusClick, false);
    document.getElementById('btnMultiply').addEventListener('click', multiplyClick, false);
    document.getElementById('btnDivide').addEventListener('click', divideClick, false);
    document.getElementById('btnClearEntry').addEventListener('click', clearEntry, false);
    document.getElementById('btnClear').addEventListener('click', clear, false);
    document.getElementById('btnEquals').addEventListener('click', equalsClick, false);
 
}