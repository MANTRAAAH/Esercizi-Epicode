const handleSubmit = function (e) {
    e.preventDefault()
    nuovoElemento()
  }
  

  function nuovoElemento(e){
    var elementText= document.getElementById("daFare").value;
    var newElement= document.createElement("li");
    newElement.textContent = elementText;
    document.getElementById("myList").appendChild(newElement);
    var bin=document.createElement("button");
    bin.innerHTML= `<i class="fas fa-trash"></i>`;
    bin.classList.add("trash");
    bin.addEventListener("click",function(){
        this.parentNode.remove();
    });
    newElement.appendChild(bin);
    var icona= document.createElement(i);
    icona.className.add("fas", "fa-trash-alt");
    bin.appendChild(icona);
    document.getElementById("myList").appendChild(newElement);
  }


window.onload = function () {
    let form = document.querySelector('form')
    form.addEventListener('submit', handleSubmit)
  }