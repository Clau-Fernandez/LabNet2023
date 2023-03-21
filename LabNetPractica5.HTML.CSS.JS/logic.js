var messageDisplay = document.getElementById("message");
var randomNumber = Math.floor(Math.random() * 20) + 1;
var score = 10;
var highScore = getHighScore();

var scoreDisplay = document.getElementById("score");
var hintDisplay = document.getElementById("hint");
var guessInput = document.getElementById("guess");
var submitBtn = document.getElementById("submit");
var resetBtn = document.getElementById("reset");
var highScoreDisplay = document.getElementById("highScore");

function updateScore() {
  scoreDisplay.textContent = score;
}

function validateGuess(guess) {
  if (isNaN(guess) || guess < 1 || guess > 20) {
    showMessage("No podes escapar...ingresa un número entre 1 y 20.");
    return false;
  }
  messageDisplay.style.display = "none";
  return true;
}

function checkGuess() {
  var guess = parseInt(guessInput.value);

  if (validateGuess(guess)) {
    if (guess === randomNumber) {
      correctGuess();
    } else {
      incorrectGuess(guess);
    }
  }
}

function correctGuess() {
  messageDisplay.style.display = "none";
  var customAlert = document.getElementById("alert-win");
  var closeBtn = document.getElementById("closeBtn-win");

  customAlert.style.display = "block";

  closeBtn.addEventListener("click", function () {
    customAlert.style.display = "none";
    reset();
  });

  if (score > highScore) {
    highScore = score;
    localStorage.setItem("highScore", highScore);
    highScoreDisplay.textContent = highScore;
  }
  reset();
}

function incorrectGuess(guess) {
  hintDisplay.textContent =
    guess > randomNumber
      ? "El número es menor ¡que pena!"
      : "El número es mayor ¡que lastima!";
  score--;
  updateScore();
  guessInput.value = "";

  if (score === 0) {
    var customAlert = document.getElementById("alert-lose");
    var closeBtn = document.getElementById("closeBtn-lose");

    customAlert.style.display = "block";

    closeBtn.addEventListener("click", function () {
      customAlert.style.display = "none";
    });
    reset();
  }
}

function showMessage(message) {
  messageDisplay.textContent = message;
  messageDisplay.style.display = "block";
}

function reset() {
  score = 10;
  updateScore();
  guessInput.value = "";
  hintDisplay.textContent = "";
  messageDisplay.style.display = "none";
  randomNumber = Math.floor(Math.random() * 20) + 1;
}

function getHighScore() {
  return localStorage.getItem("highScore") || 0;
}

highScoreDisplay.textContent = highScore;

submitBtn.addEventListener("click", checkGuess);

resetBtn.addEventListener("click", reset);
