import { createSlice } from "@reduxjs/toolkit";

export interface LoginState {
    username: string;
    password: string;
    isLoggingIn: boolean;
}

const initialState: LoginState = {
    username: '',
    password: '',
    isLoggingIn: false
}

export const loginSlice = createSlice({
    name: 'login',
    initialState,
    reducers: {
        loginStarted: (state) => {
            state.isLoggingIn = true;
        },
        loginCompleted: (state) => {
            state.isLoggingIn = false;
        }
    }
})