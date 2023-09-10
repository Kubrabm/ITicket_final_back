// wrapper
const sliderContainer = document.querySelector(".slider-container");
const sliderButtonLeft = document.querySelector(".slider-button:first-child");
const sliderButtonRight = document.querySelector(".slider-button:last-child");
const slideWidth = document.querySelector(".slider").offsetWidth;

let currentIndex = 0;

function slideLeft() {
  if (currentIndex > 0) {
    currentIndex--;
    sliderContainer.style.transform = `translateX(-${currentIndex * slideWidth}px)`;
  }
}

function slideRight() {
  if (currentIndex < sliderContainer.children.length - 1) {
    currentIndex++;
    sliderContainer.style.transform = `translateX(-${currentIndex * slideWidth}px)`;
  }
}


var currentPage = 1;

document.getElementById("load-more").addEventListener("click", function() {
  currentPage++;
  var newContent = fetchContent(currentPage); // Yeni içeriği almak için bir işlev çağırılır
  document.getElementById("content").appendChild(newContent); // Yeni içerik sayfaya eklenir
});

function fetchContent(page) {
  // Burada sayfanın içeriğini almak için gereken işlemleri yaparsınız
  // Örneğin, API çağrısı yapabilir veya başka bir yöntem kullanabilirsiniz
  // Alınan içeriği uygun bir şekilde biçimlendirip geri döndürürsünüz
  var newContent = document.createElement("div");
  newContent.textContent = "Yeni içerik sayfa " + page;
  return newContent;
}