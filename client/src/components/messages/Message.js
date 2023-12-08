import { Card, CardContent } from "@mui/material"

export const Message = ({message}) => {
    return (
      <>
        <Card sx={{ my: 2, mr: 2, border: '2px solid #e0e0e0', }}>
          <CardContent>{message.body}</CardContent>
        </Card>
      </>
    );
}