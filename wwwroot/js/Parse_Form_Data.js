async function submitformdata(event){
    event.prventDefault();

    const form = document.getElementById('Create_User_Form')

    const formData = new FormData(form);

    try {
        const response = await fetch('/Users/Create_User', {
            method: 'POST',
            body: formData 
        });

        if (response.ok) {
            const result = await response.json();
            form.reset(); 
        } else {
            const errorResult = await response.json();
        }
    } catch (error) {
        console.log('Error submitting form data:', error);
    }

}