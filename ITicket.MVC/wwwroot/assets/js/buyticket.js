const decreaseButton = document.querySelector('.decrease');
const increaseButton = document.querySelector('.increase');
const counterInput = document.querySelector('.counter input');
let ticketPrice = document.querySelector('.price span').innerHTML


increaseButton.addEventListener('click', function() {
    let currentValue = parseInt(counterInput.value);
    if (currentValue < 10) {
        counterInput.value = currentValue + 1;
    }
    document.querySelector('.price span').innerHTML = ticketPrice * counterInput.value
});

decreaseButton.addEventListener('click', function() {
    let currentValue = parseInt(counterInput.value);
    if (currentValue > 1) {
        counterInput.value = currentValue - 1;
    }
    document.querySelector('.price span').innerHTML = ticketPrice * counterInput.value
});


if (localStorage.getItem('Details') == null) {
    localStorage.setItem('Details', JSON.stringify([]));
}

let addToBasket = document.querySelector('.add');

addToBasket.onclick = function() {
    let detailsList = JSON.parse(localStorage.getItem('Details'));

    let src = document.querySelector('.ticketImage').src;
    let name = document.querySelector('#name').innerHTML;
    let date = document.querySelector('#dateinfo').innerHTML;
    let place = document.querySelector('#place').innerHTML;
    let price = document.querySelector('.ticketPrice').innerHTML + '₼';

    detailsList.push({
        Image: src,
        Name: name,
        Date: date,
        Place: place,
        Price: price,
    });


    localStorage.setItem('Details', JSON.stringify(detailsList));
};




document.querySelector('.add').onclick = function() {
    let count = document.querySelector('.counter input').value;
    document.querySelector('.basketCount').innerHTML = count;

    localStorage.setItem('basketCount', count);
};

window.onload = function() {
    let savedCount = localStorage.getItem('basketCount');
    if (savedCount !== null) {
        document.querySelector('.basketCount').innerHTML = savedCount;
    }
};





function GetDetails() {
    let detailsList = JSON.parse(localStorage.getItem('Details'))

    let x = ''

    detailsList.forEach(detail => {
        x += `
        <tr>
            <td class="img"><img src=${detail.Image}></td>
            <td>${detail.Name}</td>
            <td>${detail.Price}</td>
        </tr>
        `
    });

    document.querySelector('.innertbody').innerHTML = x

    
}

GetDetails()

let detailsList = JSON.parse(localStorage.getItem('Details'))

    document.querySelector('.add').onclick = function() {
        localStorage.setItem('Details', JSON.stringify(detailsList))

        let x = ''

        detailsList.forEach(detail => {
            x += `
            <tr>
            <td class="img"><img src=${detail.Image}></td>
            <td>${detail.Name}</td>
            <td>${detail.Price}</td>
            </tr>
            `
        })

        document.querySelector('.innertbody').innerHTML = x
        location.reload()
    }

    GetDetails()
