import { Card, CardContent } from "@mui/material"

export const Message = ({message}) => {
    return <>
    <Card sx={{my: 2}}>
        <CardContent>
            {message.body}
        </CardContent>
    </Card>
    </>
}