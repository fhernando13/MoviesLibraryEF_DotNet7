export interface User {
    id?: number;
    name: string;
    lastname: string;
    birthdate: string;       
    email: string;
    password?: string;
    role?: string; 
    nickname: string; 
    refreshToken?: string;
    refreshTokenExpireTime?: string;
    token?: string;
}