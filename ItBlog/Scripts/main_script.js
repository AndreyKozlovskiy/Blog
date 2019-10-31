var div = document.getElementById("all");
var items = document.getElementsByClassName("on_item");
var h = 1500;
//dinamic main block
//while (true) {
//    if (items.length > 4 & items.length % 2 == 0) {
//        h += 500;
//        div.style.height = h + "px";
//    }
//}
let nav = document.getElementsByClassName("nav_ul");
console.log(nav);
let elem = document.getElementsByClassName("navbar-right");
if (elem) {
    //nav[0].style.width = 140 + "%";
    elem[0].style.marginLeft = 0 +"%";
}