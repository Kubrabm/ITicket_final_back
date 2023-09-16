function GetProducts() {
    let items = JSON.parse(localStorage.getItem('row'));

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

for (let i = 0; i < countproducts.length; i++) {
    countproducts[i].addEventListener('input', changeCount)
}

function changeCount() {
    let items = JSON.parse(localStorage.getItem('products'));

    for (let i = 0; i < countproducts.length; i++) {
        let count = Number(countproducts[i].value)
        items[i].Count = count
    }

    localStorage.setItem('products', JSON.stringify(items))
    window.location.reload()
}




