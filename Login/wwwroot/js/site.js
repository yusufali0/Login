

document.addEventListener("DOMContentLoaded", function () {
    var userInput = document.getElementById('userInput');
    userInput.addEventListener("keypress", function (event) {
        if (event.key === 'Enter' || event.keyCode === 13) {
            event.preventDefault(); // Prevent default form submission behavior
            sendMessage();
        }
    });
});

//function sendMessage() {
//    var userInput = document.getElementById('userInput').value;
//    var chatMessages = document.getElementById('chatMessages');

//    var userMessage = document.createElement('div');
//    userMessage.className = 'message user';
//    userMessage.textContent = 'You: ' + userInput;
//    chatMessages.appendChild(userMessage);

//    var aiMessage = document.createElement('div');
//    aiMessage.className = 'message ai';
//    aiMessage.textContent = 'AI: ' + solveHealth(userInput);
//    chatMessages.appendChild(aiMessage);

//    // Scroll to bottom of chat messages
//    chatMessages.scrollTop = chatMessages.scrollHeight;

//    // Clear user input field
//    document.getElementById('userInput').value = '';
//}


//function solveHealth(question) {
    
//    fetch('https://aigency.dev/api/v1/my-chats?access_token=a08e0786df6f4e8f')
//        .then(response => response.json())
//        .then(data => {
//            // API'den gelen verileri kullan
//            console.log(data);
//        })
//        .catch(error => {
//            // Hata durumunda işlemler
//            console.error('Error fetching data:', error);
//        });

//}

