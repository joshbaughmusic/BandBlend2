export const dateFormatter = (date) => {
  try {

    const parts = date.split(/[-T:]/);
    const year = parseInt(parts[0], 10);
    const month = parseInt(parts[1], 10);
    const day = parseInt(parts[2], 10);
    const hours = parseInt(parts[3], 10);
    const minutes = parseInt(parts[4], 10);

    const parsedDate = new Date(year, month - 1, day, hours, minutes);

    if (isNaN(parsedDate.getTime())) {
      console.error('Invalid date:', date);
      return 'Invalid Date';
    }

    let formattedHours = hours % 12 || 12;
    formattedHours =
      formattedHours < 10 ? String(formattedHours) : formattedHours;
    const ampm = hours >= 12 ? 'PM' : 'AM';

    const formattedDate = `${month.toString().padStart(2, '0')}/${day
      .toString()
      .padStart(2, '0')}/${year} ${formattedHours}:${minutes
      .toString()
      .padStart(2, '0')} ${ampm}`;

    return formattedDate;
  } catch (error) {
    console.error('Error formatting date:', error);
    return 'Error Formatting Date';
  }
};
