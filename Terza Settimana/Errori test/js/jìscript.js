//1

const book = {
    title: "Game Of Thrones",
    category: "books",
    price: 26,
    category:"fantasy",
};
const book1=book;
book1.category="sale",
console.log(book.category)
//in questo caso console log ci mostra "sale" poichè
//sovrascrive le due proprietà "books" e "fantasy" nella const "book";
//come ho fatto a sbagliare? Boh







//2

const arrayOfNumbers= [1,2,3,4,5,6,7,8,9,10]
console.log (arrayOfNumbers.pop())  
//con il console.log di pop ci viene 
//mostrato l'elemento che viene tolto dall'array,
// non l'array stesso,poichè .pop restituisce l'oggetto



//3

let element = document.getElementsByTagName("body");
//in questo caso, la let element diventa un vero e proprio array il cui elemento
// è il body dell'html;
//seguendo questa logica, una qualsiasi
// variabile let paragrafo= document.getelementbytagName("p") diventa un array con elemento



//4
const users = [
    {name:"Jack",age:25},
    {name :"John", age:26},
];
console.log(users.age)
//avendo più proprietà dovrò iterare su di esse per entrare nella proprietà age 
//di ciascun oggetto,
//posso farlo con un forEach e una arrow function
users.forEach(user=>{
    console.log(user.age);
});


//5
const result= "1_2_3".split();
console.log(result)
// il metodo .split() converte una stringa in substringhe e le ritorna in un array, di solito
// è bene specificare il separatore nelle parentesi
// (es. "_" oppure " " per dividere dagli spazi, oppure "|" )
//una volte convertite, le stringhe diventano oggetti singoli di un array.


//6
const myFunction= (firstParameter, secondParameter) => {
    console.log (`${firstParameter} ${secondParameter}`)
}
myFunction("Hello,World")

//in questo caso il console log darà "Hello, world undefined" perchè il secondo parametro è omesso

//9
function foo(){
    console.log("I'm foo")
}

//non viene visualizzato nulla perchè la funzione non è stata invocata

//10
const arr1= [0];
const arr2=[1,2,3];
arr1.push(arr2);
console.log("last: "+ arr1.pop()+ "length: " +arr1.length)
console.log(arr2)



const animali=["cane","gatto","topo"]
const animali2=["scimmia","squalo","elefante"]
animali.push("gerardo")
console.log(animali)