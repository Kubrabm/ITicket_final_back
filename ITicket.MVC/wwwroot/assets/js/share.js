let share = document.querySelector('#sharebtn')
let close = document.querySelector('.close')

sharebtn.onclick = function() {
    share.classList.remove('d-none')
}

let close4 = document.querySelector('#close4')
close4.onclick = function() {
  share.classList.add('d-none')
}



