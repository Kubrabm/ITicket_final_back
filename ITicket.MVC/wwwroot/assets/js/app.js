let options = document.querySelector('.options')
let navbar_options = document.querySelector('.navbar_options')

options.onclick = () => navbar_options.classList.toggle('d-none')


//Slider
document.addEventListener('DOMContentLoaded', () => {
    const carousels = document.querySelectorAll('.carousel');
    
        carousels.forEach(carousel => {
            const arrows = carousel.parentElement.querySelectorAll('.wrapper i');
            const firstCardWidth = carousel.querySelector('.card').offsetWidth;
            const carouselChildren = [...carousel.children];
    
            let cardPerView = Math.round(carousel.offsetWidth / firstCardWidth);
    
            carouselChildren.slice(-cardPerView).reverse().forEach(card => {
                carousel.insertAdjacentHTML('afterbegin', card.outerHTML);
            });
    
            carouselChildren.slice(0, cardPerView).forEach(card => {
                carousel.insertAdjacentHTML('beforeend', card.outerHTML);
            });
    
            arrows.forEach(arrow => {
                arrow.addEventListener('click', () => {
                    const scrollAmount = arrow.id === 'left' ? -firstCardWidth : firstCardWidth;
                    carousel.scrollBy({ left: scrollAmount, behavior: 'smooth' });
                });
            });
    
            let isDragging = false, startX, startScrollLeft, timeIntervalId;
    
            const dragStart = (e) => {
                isDragging = true;
                carousel.classList.add('dragging');
                startX = e.pageX;
                startScrollLeft = carousel.scrollLeft;
            };
    
            const dragging = (e) => {
                if (!isDragging) return;
                carousel.scrollLeft = startScrollLeft - (e.pageX - startX);
            };
    
            const dragStop = () => {
                isDragging = false;
                carousel.classList.remove('dragging');
            };
    
            const infiniteScroll = () => {
                if (carousel.scrollLeft === 0) {
                    carousel.classList.add('no-transition');
                    carousel.scrollLeft = carousel.scrollWidth - (2 * carousel.offsetWidth);
                    carousel.classList.remove('no-transition');
                } else if (Math.ceil(carousel.scrollLeft) === carousel.scrollWidth - carousel.offsetWidth) {
                    carousel.classList.add('no-transition');
                    carousel.scrollLeft = carousel.offsetWidth;
                    carousel.classList.remove('no-transition');
                }
            };
    
            const autoPlay = () => {
                timeIntervalId = setInterval(() => {
                    const maxScrollLeft = carousel.scrollWidth - carousel.offsetWidth;
                    if (carousel.scrollLeft >= maxScrollLeft) {
                        carousel.scrollLeft = 0;
                    } else {
                        carousel.scrollLeft += firstCardWidth;
                    }
                }, 2500);
            };
    
            autoPlay();
    
            carousel.addEventListener('mousedown', dragStart);
            carousel.addEventListener('mousemove', dragging);
            document.addEventListener('mouseup', dragStop);
            carousel.addEventListener('scroll', infiniteScroll);
        });
    });
    
    
//ScrollDown
function scrollDown() {
        window.scrollBy(0, 700); 
}
    
    
// Change language
let langs = document.querySelectorAll('.left_side .lang a')

for(let lang of langs) {
    lang.onclick = function(e) {
        e.preventDefault()
        
        for(let lang of langs) {
            this.classList.add('d-none')
            lang.classList.remove('d-none')

            if(lang.innerHTML == 'RU') {
                this.classList.add('d-none')
            }
        }
    }
}

//login
let user = document.querySelector('#user')
let login = document.querySelector('.login')
let close = document.querySelector('#close_login')
const body = document.body;


user.onclick = function() {
  login.classList.remove('d-none')
  body.style.backgroundColor = "rgba(0, 0, 0, 0.5)";
}

close.onclick = function() {
  login.classList.add('d-none')
  body.style.backgroundColor = "#e5e7eb";
}


close.onclick = function() {
  login.classList.add('d-none')
  body.style.backgroundColor = "#e5e7eb";
}

//forget
let resetpassword = document.querySelector('.forgetpassword')
let forgot = document.querySelector('#forget')
let closeforget = document.querySelector('#close_forget')


forgot.onclick = function() {
  resetpassword.classList.remove('d-none')
  login.classList.add('d-none')
  body.style.backgroundColor = "rgba(0, 0, 0, 0.5)";
}

closeforget.onclick = function() {
  resetpassword.classList.add('d-none')
  body.style.backgroundColor = "#e5e7eb";
}

//signin

let signin = document.querySelector('.signin')
let registration = document.querySelector('.registration')
let closesignin = document.querySelector('#close_signin')

registration.onclick = function() {
  login.classList.add('d-none')
  signin.classList.remove('d-none')
  body.style.backgroundColor = "rgba(0, 0, 0, 0.5)";
}

closesignin.onclick = function() {
  signin.classList.add('d-none')
  body.style.backgroundColor = "#e5e7eb";
}


//call back

let callback = document.querySelector('.callback')
callback.onclick = function() {
  resetpassword.classList.add('d-none')
  user.onclick()
}


//return blog 
let signinlink = document.querySelector('.signinlink')
let returnlog = document.querySelector('#returnlog')

returnlog.addEventListener('click', function() {
  signin.classList.toggle('d-none')
  login.classList.toggle('d-none')
})



//Range
document.addEventListener('DOMContentLoaded', function() {
    const rangeOne = document.querySelector('input[name="rangeOne"]');
    const rangeTwo = document.querySelector('input[name="rangeTwo"]');
    const rangeValueArea = document.querySelector('#rangevaluearea');

    rangeOne.addEventListener('input', updateRangeValues);
    rangeTwo.addEventListener('input', updateRangeValues);

    function updateRangeValues() {
        const value1 = parseFloat(rangeOne.value).toFixed(2);
        const value2 = parseFloat(rangeTwo.value).toFixed(2);
        rangeValueArea.innerHTML = `Qiymət ${value1}-₼-dan ${value2}-₼-dək`;
    }
});



const datePicker = document.getElementById("datePicker");
    const calendar = document.getElementById("calendar");

    datePicker.addEventListener("click", function () {
        calendar.style.display = "block";
    });

    calendar.addEventListener("change", function () {
        const selectedDate = new Date(calendar.value);
        const options = { year: 'numeric', month: 'long', day: 'numeric' };
        const formattedDate = selectedDate.toLocaleDateString('tr-TR', options);

        datePicker.innerHTML =  formattedDate;
        calendar.style.display = "none";
 });



 

var boxes = document.querySelectorAll(' #boxrow .box');
    
var visibleBoxCount = 9;

function loadMoreBoxes() {
    for (var i = 0; i < boxes.length; i++) {
        if (i < visibleBoxCount) {
            boxes[i].style.display = 'block';
        } else {
            boxes[i].style.display = 'none';
        }
    }
    visibleBoxCount += 9;

}

document.getElementById('load-more').addEventListener('click', loadMoreBoxes);

window.addEventListener('load', loadMoreBoxes);