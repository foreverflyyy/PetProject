import '../styles/user.css'

interface ErrorMessageProps {
   message: string
}

export function ErrorMessage({ message }: ErrorMessageProps) {
   return (
      <p className="error-request">{message}</p>
   )
}