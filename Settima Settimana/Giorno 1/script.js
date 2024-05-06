

//ESERCIZIO 1

class User {
    constructor(_firstName, _lastName, _age, _location) {
        this.firstName = _firstName
        this.lastName = _lastName
        this.age = _age
        this.location = _location
    }
    compareAge(otherUser) {
        if (this.age > otherUser.age) {
            return `${this.firstName} ${this.lastName} è più vecchio di ${otherUser.firstName} ${otherUser.lastName}`;
        } else if (this.age < otherUser.age) {
            return `${this.firstName} ${this.lastName} è più giovane ${otherUser.firstName} ${otherUser.lastName}`;
        } else {
            return `${this.firstName} ${this.lastName} ha la stessa età di ${otherUser.firstName} ${otherUser.lastName}`;
        }
    }
}



const user1 = new User('Charles', 'Leclerc', 26, "Monte Carlo");
const user2 = new User('Lando', 'Norris', 24, 'Bristol');

console.log(user1.compareAge(user2));


//ESERCIZIO 2
class Pet {
    constructor(_petName, _ownerName, _species, _breed) {
        this.petName = _petName;
        this.ownerName = _ownerName;
        this.species = _species;
        this.breed = _breed;
    }

    isSameOwner(otherPet) {
        return this.ownerName === otherPet.ownerName;
    }
}

const pet1 = new Pet('Falco', 'Giorgio', 'Cat', 'Siamese');
const pet2 = new Pet('Fuffy', 'Giorgio', 'Cat', 'Caracal');

console.log(pet1.isSameOwner(pet2));


document.querySelector('form').addEventListener('submit', (event) => {
    event.preventDefault();

    const petName = document.getElementById('pet_name_input').value;
    const ownerName = document.getElementById('owner_name_input').value;
    const species = document.querySelector('select').value;
    const breed = document.getElementById('pet_breed_input').value;

    const newPet = new Pet(petName, ownerName, species, breed);

    // Add the new pet to the list
    const petList = document.getElementById('pet_list');
    const petItem = document.createElement('div');
    petItem.classList.add('col', 'border', 'p-3', 'mb-3', 'mt-2');
    petItem.innerHTML = `
        <h3>${newPet.petName}</h3>
        <p><strong>Owner:</strong> ${newPet.ownerName}</p>
        <p><strong>Species:</strong> ${newPet.species}</p>
        <p><strong>Breed:</strong> ${newPet.breed}</p>
    `;
    petList.appendChild(petItem);

    // Clear the form inputs
    document.querySelector('form').reset();
});
