let hamburger_icon = document.querySelector('.hamburger_icon')

hamburger_icon.onclick = function() {
    document.querySelector('.hamburger').classList.remove('d-none')
    hamburger_icon.classList.add('d-none')
}
let hamburger_close = document.querySelector('.hamburger_close')

hamburger_close.onclick = function() {
    document.querySelector('.hamburger').classList.add('d-none')
    hamburger_icon.classList.remove('d-none')

}