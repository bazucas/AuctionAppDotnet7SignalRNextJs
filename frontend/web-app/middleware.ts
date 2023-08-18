export { default } from "next-auth/middleware"

// protect session route with signin if not signed in
export const config = {
    matcher: [
        '/session'
    ],
    pages: {
        signIn: '/api/auth/signin'
    }
}