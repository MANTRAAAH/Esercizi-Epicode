
const getBooks = async () => {
    try {
        const response = await fetch('https://striveschool-api.herokuapp.com/books');
        if (response.ok) {
            return await response.json();
        } else {
            throw new Error('Failed to fetch books');
        }
    } catch (error) {
        console.error('Error:', error.message);
    }
};

const displayBooks = (books) => {
    const booksShowcase = document.getElementById('books_showcase');

    books.forEach(book => {
        const card = document.createElement('div');
        card.classList.add('col', 'col-md-4', 'col-lg-3', 'col-xl-2', "mb-3");

        const cardInner = document.createElement('div');
        cardInner.classList.add('card', 'h-100', "shadow");

        const cardImage = document.createElement('img');
        cardImage.classList.add('card-img-top', 'flex-grow-1');
        cardImage.src = book.img;
        cardImage.alt = book.title;

        const cardBody = document.createElement('div');
        cardBody.classList.add('card-body');

        const cardTitle = document.createElement('h5');
        cardTitle.classList.add('card-title');
        cardTitle.textContent = book.title;

        const cardPrice = document.createElement('p');
        cardPrice.classList.add('card-text');
        cardPrice.textContent = `$${book.price}`;

        const discardButton = document.createElement('button');
        discardButton.classList.add('btn', 'btn-danger', "shadow");
        discardButton.textContent = 'Scarta';
        discardButton.addEventListener('click', () => discardBook(card));

        cardBody.appendChild(cardTitle);
        cardBody.appendChild(cardPrice);
        cardBody.appendChild(discardButton);

        cardInner.appendChild(cardImage);
        cardInner.appendChild(cardBody);

        card.appendChild(cardInner);

        booksShowcase.appendChild(card);
    });
};

const discardBook = (card) => {
    card.remove();
};

window.addEventListener('DOMContentLoaded', async () => {
    const books = await getBooks();
    if (books) {
        displayBooks(books);
    }
});