document.addEventListener('DOMContentLoaded', function() {
    // Function to extract video information from URL parameters
    function getVideoInfoFromURL() {
        const urlParams = new URLSearchParams(window.location.search);
        const title = urlParams.get('title');
        const videoUrl = urlParams.get('url');
        return { title, videoUrl };
    }

    // Function to load and display the video
    function loadVideo(title, videoUrl) {
        const videoElement = document.querySelector('#videoPlayer');
        const videoTitleElement = document.querySelector('#videoTitle');

        videoElement.src = videoUrl;
        videoTitleElement.textContent = title;
    }

    // Function to shuffle an array
    function shuffle(array) {
        for (let i = array.length - 1; i > 0; i--) {
            const j = Math.floor(Math.random() * (i + 1));
            [array[i], array[j]] = [array[j], array[i]];
        }
        return array;
    }

    // Function to shuffle the recommendation videos
    function shuffleRecommendations() {
        const recommendationBox = document.getElementById('recommendationBox');
        const recommendations = Array.from(recommendationBox.children);
        const shuffledRecommendations = shuffle(recommendations);

        // Clear the existing recommendations
        recommendationBox.innerHTML = '';

        // Append the shuffled recommendations
        shuffledRecommendations.forEach(video => {
            recommendationBox.appendChild(video);
        });
    }

    // Get video information from URL parameters
    const { title, videoUrl } = getVideoInfoFromURL();

    // Load and display the video
    loadVideo(title, videoUrl);

    // Shuffle the recommendations
    shuffleRecommendations();
});