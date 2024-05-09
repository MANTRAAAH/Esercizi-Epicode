document.querySelector('.btn-primary').addEventListener('click', function () {

    var query = 'coding';
    var apiKey = 'I39MRkzmevNwfsbkdI8pIT3aaNV1tUFAM27FH7TQr7xZpbAZlMtHJCoR';
    var url = 'https://api.pexels.com/v1/search?query=' + query;

    fetch(url, {
        headers: {
            Authorization: apiKey
        }
    })
        .then(response => response.json())
        .then(data => {
            var cards = document.querySelectorAll('.card');

            data.photos.forEach((photo, index) => {
                if (index < cards.length) {
                    var cardImage = cards[index].querySelector('.card-img-top');
                    cardImage.src = photo.src.medium;


                    var cardText = cards[index].querySelector('.text-muted');
                    cardText.textContent = photo.id;
                }
            });
        });
});

document.querySelector('.btn-secondary').addEventListener('click', function () {

    var query = 'funny cats';
    var apiKey = 'I39MRkzmevNwfsbkdI8pIT3aaNV1tUFAM27FH7TQr7xZpbAZlMtHJCoR';
    var url = 'https://api.pexels.com/v1/search?query=' + query;

    fetch(url, {
        headers: {
            Authorization: apiKey
        }
    })
        .then(response => response.json())
        .then(data => {
            var cards = document.querySelectorAll('.card');

            data.photos.forEach((photo, index) => {
                if (index < cards.length) {
                    var cardImage = cards[index].querySelector('.card-img-top');
                    cardImage.src = photo.src.medium;


                    var editButton = cards[index].querySelector('.btn-outline-secondary');
                    if (editButton) {
                        editButton.parentNode.removeChild(editButton);
                    }


                    var btnGroup = cards[index].querySelector('.btn-group');
                    var hideButton = document.createElement('button');
                    hideButton.type = 'button';
                    hideButton.className = 'btn btn-sm btn-outline-secondary';
                    hideButton.textContent = 'Hide';

                    hideButton.addEventListener('click', function () {
                        cards[index].style.display = 'none';
                    });

                    btnGroup.appendChild(hideButton);


                    var cardText = cards[index].querySelector('.text-muted');
                    cardText.textContent = photo.id;
                }
            });
        });
});


document.querySelectorAll('.btn-outline-secondary').forEach(button => {
    button.addEventListener('click', function () {
        var card = this.closest('.card');
        card.style.display = 'none';
    });
});


document.querySelector('.btn-search').addEventListener('click', function () {

    var query = document.querySelector('.search-input').value;


    var apiKey = 'I39MRkzmevNwfsbkdI8pIT3aaNV1tUFAM27FH7TQr7xZpbAZlMtHJCoR';
    var url = 'https://api.pexels.com/v1/search?query=' + query;

    fetch(url, {
        headers: {
            Authorization: apiKey
        }
    })
        .then(response => response.json())
        .then(data => {
            var cards = document.querySelectorAll('.card');

            var cardContainer = document.getElementById('card-container');
            while (cardContainer.firstChild) {
                cardContainer.removeChild(cardContainer.firstChild);
            }


            cards.forEach(card => card.parentNode.removeChild(card));


            data.photos.forEach(photo => {
                var newCol = document.createElement('div');
                newCol.className = 'col-md-4';
                var newCard = document.createElement('div');
                newCard.className = 'card mb-3';

                var newCardImage = document.createElement('img');
                newCardImage.className = 'card-img-top';
                newCardImage.src = photo.src.medium;

                var newCardBody = document.createElement('div');
                newCardBody.className = 'card-body', 'flex-grow-1';

                var newCardTitle = document.createElement('h5');
                newCardTitle.className = 'card-title';
                newCardTitle.textContent = photo.photographer;

                var newCardText = document.createElement('small');
                newCardText.className = 'card-text', 'fs-6';
                newCardText.textContent = `Photo ID: ${photo.id}`;

                var newCardFooter = document.createElement('div');
                newCardFooter.className = 'card-footer';

                var newCardButton = document.createElement('button');
                newCardButton.className = 'btn btn-primary';
                newCardButton.textContent = 'Details';

                newCardFooter.appendChild(newCardButton);

                newCardBody.appendChild(newCardTitle);
                newCardBody.appendChild(newCardText);
                newCardBody.appendChild(newCardFooter);

                newCard.appendChild(newCardImage);
                newCard.appendChild(newCardBody);
                newCol.appendChild(newCard);

                document.getElementById('card-container').appendChild(newCol);
            });
        });
});
