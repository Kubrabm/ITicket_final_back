
// Basketsecond
let basket_icon = document.querySelector('.basket_icon')
let basket_box = document.querySelector('.basketsecond')

basket_icon.onclick = function() {
  basket_box.classList.toggle('d-none')
  body.style.backgroundColor = "rgba(0, 0, 0, 0.5)";

}


