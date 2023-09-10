let faq_buttons = document.querySelectorAll('.faq button')
let faq_answers = document.querySelectorAll('.faq .answer')


for(let button of faq_buttons) {
    button.onclick = function(e) {
        e.preventDefault()
        let id = this.getAttribute('data-id')


        for(let answer of faq_answers) {

            if(id == answer.id) {
                answer.classList.toggle('d-none')
            }

        }
    }
}






