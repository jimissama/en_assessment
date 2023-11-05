async function findCords() {
    const getCurrentPosition = () => new Promise((resolve, error) => navigator.geolocation.getCurrentPosition(resolve, error));

    try {
        const Data = await getCurrentPosition();
        return `${Data?.coords?.latitude}*${Data?.coords?.longitude}`;
    }
    catch (error) {        
        return '';
    }
};