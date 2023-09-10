const openSearchButton = document.getElementById("openSearchButton");
const closeSearchButton = document.getElementById("closeSearchButton");
const searchButton = document.getElementById("searchButton");
const serachbtn = document.getElementById("serachbtn");
const searchInput = document.getElementById("searchInput");
const resultDiv = document.getElementById("result");

openSearchButton.addEventListener("click", () => {
  serachbtn.style.display = "block";
});

closeSearchButton.addEventListener("click", () => {
  serachbtn.style.display = "none";
});

searchButton.addEventListener("click", () => {
    const searchText = searchInput.value;
    resultDiv.textContent = "Aranan: " + searchText;
});