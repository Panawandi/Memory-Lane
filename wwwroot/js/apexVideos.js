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

// Wait for the DOM content to be fully loaded
window.addEventListener('DOMContentLoaded', () => {
    
    const videoPlayer = document.getElementById('videoPlayer');
    const videoWrapper = document.getElementById('videoWrapper');

    // Listen for the loadedmetadata event to get the video dimensions
    videoPlayer.addEventListener('loadedmetadata', () => {
    const videoWidth = videoPlayer.videoWidth;
    const videoHeight = videoPlayer.videoHeight;

    // Set the width and height of the video wrapper
    videoWrapper.style.width = videoWidth + 'px';
    videoWrapper.style.height = videoHeight + 'px';

    });
});