//async function sendMessage() {
//    const message = document.getElementById("message").value;
//    const apiUrl = "/Home/SendMessage"; 

//    const formData = new URLSearchParams();
//    formData.append("message", message);

//    try {
//        const response = await fetch(apiUrl, {
//            method: "POST",
//            headers: {
//                "Content-Type": "application/x-www-form-urlencoded; charset=UTF-8"
//            },
//            body: formData
//        });

//        if (response.ok) {
//            const data = await response.text();
//            appendMessage(data, 'response');
//        } else {
//            const errorText = await response.text();
//            console.error(`API Error: ${errorText}`);
//            appendMessage(`Error: ${response.statusText}`, 'error');
//        }
//    } catch (error) {
//        console.error(`Fetch Error: ${error.message}`);
//        appendMessage(`Error: ${error.message}`, 'error');
//    }
//}

//document.addEventListener("DOMContentLoaded", function () {
//    var userInput = document.getElementById('userInput');
//    userInput.addEventListener("keypress", function (event) {
//        if (event.key === 'Enter' || event.keyCode === 13) {
//            event.preventDefault(); // Prevent default form submission behavior
//            sendMessage();
//        }
//    });
//});

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

