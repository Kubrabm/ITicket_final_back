// const decreaseButton = document.querySelector('.decrease');
// const increaseButton = document.querySelector('.increase');
// const counterInput = document.querySelector('.counter input');
// let ticketPrice = document.querySelector('.price span').innerHTML


// increaseButton.addEventListener('click', function() {
//     let currentValue = parseInt(counterInput.value);
//     if (currentValue < 10) {
//         counterInput.value = currentValue + 1;
//     }
//     document.querySelector('.price span').innerHTML = ticketPrice * counterInput.value
// });

// decreaseButton.addEventListener('click', function() {
//     let currentValue = parseInt(counterInput.value);
//     if (currentValue > 1) {
//         counterInput.value = currentValue - 1;
//     }
//     document.querySelector('.price span').innerHTML = ticketPrice * counterInput.value
// });


// if (localStorage.getItem('Details') == null) {
//     localStorage.setItem('Details', JSON.stringify([]));
// }

// let addToBasket = document.querySelector('.add');

// addToBasket.onclick = function() {
//     let detailsList = JSON.parse(localStorage.getItem('Details'));

//     let src = document.querySelector('.ticketImage').src;
//     let name = document.querySelector('#name').innerHTML;
//     let date = document.querySelector('#dateinfo').innerHTML;
//     let place = document.querySelector('#place').innerHTML;
//     let price = document.querySelector('.ticketPrice').innerHTML + '₼';

//     detailsList.push({
//         Image: src,
//         Name: name,
//         Date: date,
//         Place: place,
//         Price: price,
//     });


//     localStorage.setItem('Details', JSON.stringify(detailsList));
// };




// document.querySelector('.add').onclick = function() {
//     let count = document.querySelector('.counter input').value;
//     document.querySelector('.basketCount').innerHTML = count;

//     localStorage.setItem('basketCount', count);
// };

// window.onload = function() {
//     let savedCount = localStorage.getItem('basketCount');
//     if (savedCount !== null) {
//         document.querySelector('.basketCount').innerHTML = savedCount;
//     }
// };





// function GetDetails() {
//     let detailsList = JSON.parse(localStorage.getItem('Details'))

//     let x = ''

//     detailsList.forEach(detail => {
//         x += `
//         <tr>
//             <td class="img"><img src=${detail.Image}></td>
//             <td>${detail.Name}</td>
//             <td>${detail.Price}</td>
//         </tr>
//         `
//     });

//     document.querySelector('.innertbody').innerHTML = x

    
// }

// GetDetails()

// let detailsList = JSON.parse(localStorage.getItem('Details'))

//     document.querySelector('.add').onclick = function() {
//         localStorage.setItem('Details', JSON.stringify(detailsList))

//         let x = ''

//         detailsList.forEach(detail => {
//             x += `
//             <tr>
//             <td class="img"><img src=${detail.Image}></td>
//             <td>${detail.Name}</td>
//             <td>${detail.Price}</td>
//             </tr>
//             `
//         })

//         document.querySelector('.innertbody').innerHTML = x
//         location.reload()
//     }

//     GetDetails()
function GetProducts() {
    let items = JSON.parse(localStorage.getItem('products'));

    let alertbox = document.querySelector('.alert');

    if (items.length === 0) {
        alertbox.classList.remove('d-none')
        document.querySelector('table').classList.add('d-none')
    }
    else {
        alertbox.classList.add('d-none')
        document.querySelector('.chart').classList.remove('d-none')

        let x = '';
        items.forEach(item => {
            console.log(item);
            x += `<div class="col-12">
        <ul id="${item.Id}">
            <li>
                <img src="${item.Image}" alt="">
            </li>
            <li>
                ${item.Name}
            </li>
            <li>
                <input type="number" name="" min="1" value="${item.Count}" id="Count_prod">
            </li>
            <li>
               ${item.Price * item.Count} AZN
            </li>
            <li>
                <button type="button" class="btn btn-danger">
                    delete
                </button>
            </li>
        </ul>
    </div>
        `
        })
        document.querySelector('#save_products').innerHTML = x;

    }
}

GetProducts();

let delete_btns = document.querySelectorAll('.btn-danger');

for (let btn of delete_btns) {
    btn.addEventListener('click', function (e) {
        e.preventDefault();

        let id = btn.parentElement.parentElement.id;
        let items = JSON.parse(localStorage.getItem('products'));

        let new_chart = items.filter(item => item.Id !== id);
        console.log(new_chart);
        localStorage.setItem('products', JSON.stringify(new_chart));
        location.reload()
    })
}


let countproducts = document.querySelectorAll('#Count_prod')

for(let i = 0; i < countproducts.length; i++) {
    countproducts[i].addEventListener('input', changeCount)
}

function changeCount() {
    let items = JSON.parse(localStorage.getItem('products'));

    for(let i = 0; i < countproducts.length; i++) {
        let count = Number(countproducts[i].value)
        items[i].Count = count
    }

    localStorage.setItem('products', JSON.stringify(items))
    window.location.reload()
}