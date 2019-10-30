var div = document.getElementById("all");
var items = document.getElementsByClassName("on_item");
var h = 1500;

    if (items.length > 4) {
        div.style.height = h + "px";
        if ((items.length > 6) & (items.length % 2 == 1)) {
        h += 500;
        div.style.height = h + "px";
    }
}
console.log(items.length);