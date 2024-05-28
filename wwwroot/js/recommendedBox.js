// Function to shuffle an array
function shuffle(array) {
    for (let i = array.length - 1; i > 0; i--) {
        const j = Math.floor(Math.random() * (i + 1));
        [array[i], array[j]] = [array[j], array[i]];
    }
    return array;
}

// Wait for the DOM content to be fully loaded
document.addEventListener('DOMContentLoaded', function() {
    // Get the recommendation box container
    const recommendationBox = document.getElementById('recommendationBox');

    // Get all the recommendation video containers
    const recommendationVideos = Array.from(recommendationBox.children);

    // Shuffle the recommendation video containers
    const shuffledRecommendationVideos = shuffle(recommendationVideos);

    // Clear the original container
    recommendationBox.innerHTML = '';

    // Append the shuffled recommendation video containers back to the parent container
    shuffledRecommendationVideos.forEach(video => {
        recommendationBox.appendChild(video);
    });
});