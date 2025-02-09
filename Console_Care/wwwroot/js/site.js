// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let list = document.querySelectorAll(".mynav li")
function activelink() {
    list.forEach((item) => {
        item.classList.remove("hovered")
    });
    this.classList.add("hovered");

}

list.forEach((item) => item.addEventListener("click", activelink));
//------------------filter-------

function search() {
    let searchbar = document.querySelector("#searchinput").value.toUpperCase();
    let orderslist = document.querySelector(".mytable")
    let order = document.querySelectorAll(".order")
    let searchstate = document.querySelectorAll(".searchstate");
    let ordername = document.querySelectorAll(".namesearch");

    for (var j = 0; j < searchstate.length; j++) {
        if (searchstate[j].innerHTML.toUpperCase().indexOf(searchbar) >= 0) {
            order[j].style.display = "";
        } else {
            order[j].style.display = "none";
        }
    }
    for (var i = 0; i < ordername.length; i++) {
        if (ordername[i].innerHTML.toUpperCase().indexOf(searchbar) >= 0) {
            order[i].style.display = "";
        } else {
            order[i].style.display = "none";
        }
    }
    
}

function filter() {
    // جلب القيمة المختارة من select
    let filtername = document.querySelector("#filtername").value;
    let filterps = document.querySelector("#filterps").value;
    let filterCity = document.querySelector("#filterCity").value;
    let filterTypeOfCustomer = document.querySelector("#filterTypeOfCustomer").value;
    let filterNameofassistent = document.querySelector("#filterNameofassistent").value;

    let orderslist = document.querySelector(".mytable");
    let order = document.querySelectorAll(".order");
    let searchstate = document.querySelectorAll(".searchstate");
    let ordername = document.querySelectorAll(".namesearch");

    console.log(filtername);
    console.log(filterps); 

    
    for (var i = 0; i < ordername.length; i++) {
        if ((ordername[i].innerHTML.indexOf(filterps) >= 0 || filterps === "all" )&&
            (ordername[i].innerHTML.indexOf(filtername) >= 0 || filtername === "all")
            &&
            (ordername[i].innerHTML.indexOf(filterCity) >= 0 || filterCity === "all")
            &&
            (ordername[i].innerHTML.indexOf(filterTypeOfCustomer) >= 0 || filterTypeOfCustomer === "all")
            &&
            (ordername[i].innerHTML.indexOf(filterNameofassistent) >= 0 || filterNameofassistent === "all")) {
            order[i].style.display = ""; 
        } else {
            order[i].style.display = "none"; 
        }
    }
}
//--------------------validattion--------
function filter2() {
    // جلب القيمة المختارة من select
    let filtername = document.querySelector("#filtername").value;
               
    let filterps = document.querySelector("#filterps").value;
    var filterCity = document.querySelector("#filterCity").value;


    let orderslist = document.querySelector(".mytable");
    let order = document.querySelectorAll(".order");
    let searchstate = document.querySelectorAll(".searchstate");
    let ordername = document.querySelectorAll(".namesearch");

    console.log(filtername);
    console.log(filterCity);


    for (var i = 0; i < ordername.length; i++) {
        if ((ordername[i].innerHTML.indexOf(filterps) >= 0 || filterps === "all") &&
            (ordername[i].innerHTML.indexOf(filtername) >= 0 || filtername === "all")
            &&
            (ordername[i].innerHTML.indexOf(filterCity) >= 0 || filterCity === "all")) {
            order[i].style.display = "";
        } else {
            order[i].style.display = "none";
        }
    }
}//--------------------validattion--------
function filter1() {
    // جلب القيمة المختارة من select
    let filterdate = document.querySelector("#filterdate").value;
    let order = document.querySelectorAll(".order");
    let ordername = document.querySelectorAll(".namesearch");

    for (var i = 0; i < ordername.length; i++) {
        if (ordername[i].innerHTML.indexOf(filterdate) >= 0 || filterdate === "all") {
            order[i].style.display = "";
        } else {
            order[i].style.display = "none";
        }
    }
}

//--------------filteremp-------------------

function filteremp() {
    // جلب القيمة المختارة من select
    let filternameemp = document.querySelector("#filternameemp").value;
    let filterrole = document.querySelector("#filterrole").value;

    let order = document.querySelectorAll(".orderemp");
    let ordername = document.querySelectorAll(".namesearch");
    console.log(filternameemp);


    for (var i = 0; i < ordername.length; i++) {
        if ((ordername[i].innerHTML.indexOf(filternameemp) >= 0 || filternameemp === "all" || filternameemp == 0) &&
            (ordername[i].innerHTML.indexOf(filterrole) >= 0 || filterrole === "all" || filterrole == 0)) {
            order[i].style.display = "";
        } else {
            order[i].style.display = "none";
        }
    }
}

//----------------------------------------------
function filterorder() {
    // جلب القيمة المختارة من select
    let filtername = document.querySelector("#filtername").value;
    let filterps = document.querySelector("#filterps").value;
    let filterCity = document.querySelector("#filterCity").value;
    let filterTypeOfCustomer = document.querySelector("#filterTypeOfCustomer").value;

    let orderslist = document.querySelector(".mytable");
    let order = document.querySelectorAll(".order");
    let searchstate = document.querySelectorAll(".searchstate");
    let ordername = document.querySelectorAll(".namesearch");

    console.log(filtername);
    console.log(filterps);


    for (var i = 0; i < ordername.length; i++) {
        if ((ordername[i].innerHTML.indexOf(filterps) >= 0 || filterps === "all") &&
            (ordername[i].innerHTML.indexOf(filtername) >= 0 || filtername === "all")
            &&
            (ordername[i].innerHTML.indexOf(filterCity) >= 0 || filterCity === "all")
            &&
            (ordername[i].innerHTML.indexOf(filterTypeOfCustomer) >= 0 || filterTypeOfCustomer === "all")) {
            order[i].style.display = "";
        } else {
            order[i].style.display = "none";
        }
    }
}
//-------------------------------------------
document.getElementById('dl-csvorder').addEventListener('click', function () {
    var table2excel = new Table2Excel();
    table2excel.export(document.getElementById("tblorder"));
})

//----------------------------------------------

function myalert() {
    Swal.fire({
        title: " 💙تم حفظ طلبكم سنتصل بك قريبا",
        width: 600,
        padding: "3em",
        color: "#716add",
        background: "#fff url(https://sweetalert2.github.io/images/trees.png)",
        backdrop: `
    rgba(0,0,123,0.4)
    url("https://i.gifer.com/6kc.gif")
     top
    no-repeat
  `
    });
}
//-----------------------------
var a;
var b;
function pass() {
    if (a == 1) {
        document.getElementById('password').type = 'password';
        document.getElementById('passicon').src = '/img/images1.png';
        a = 0;
    } else {
        document.getElementById('password').type = 'text';
        document.getElementById('passicon').src = '/img/show.png';
        a = 1;

    }
}
function passconfirm() {
    if (b == 1) {
        document.getElementById('passwordconfirm').type = 'password';
        document.getElementById('passiconconfirm').src = '/img/images1.png';
        b = 0;
    } else {
        document.getElementById('passwordconfirm').type = 'text';
        document.getElementById('passiconconfirm').src = '/img/show.png';
        b = 1;

    }
}