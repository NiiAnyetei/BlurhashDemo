# BlurhashDemo

A demo project showcasing the usage of [Blurhash](https://blurha.sh/) for image placeholders in both React and Angular frontend applications, with an ASP.NET Core backend for generating Blurhash strings from uploaded images.

## Demo

React

![Watch the video](https://imgur.com/htAiqQc.gif)

Angular

![Watch the video](https://imgur.com/UqX1MEW.gif)

Swagger

![Watch the video](https://imgur.com/5s7iWdE.png)

## Table of Contents

- [Introduction](#introduction)
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Installation](#installation)
- [Usage](#usage)
- [API Endpoints](#api-endpoints)
- [React Frontend Integration](#react-frontend-integration)
- [Angular Frontend Integration](#angular-frontend-integration)
- [ASP.NET Core Backend Integration](#aspnet-core-backend-integration)
- [Examples](#examples)

## Introduction

This demo project demonstrates the use of Blurhash to display low-resolution image placeholders while the full image is loading. The project includes two frontend applications built with React and Angular and an ASP.NET Core backend for generating Blurhash strings.

## Features

- **React and Angular Frontend**: Display Blurhash placeholders while the high-resolution images load.
- **ASP.NET Core Backend**: Generates Blurhash strings from uploaded images.
- Supports API integration for image upload and Blurhash generation.
- Seamless integration between frontend (React/Angular) and backend (ASP.NET Core).

## Technologies Used

- **Frontend**:
  - React (React app for Blurhash rendering)
    - [React Lazy Load Image Component](https://www.npmjs.com/package/react-lazy-load-image-component)
    - [React Blurhash Component](https://www.npmjs.com/package/react-blurhash)
  - Angular (Angular app for Blurhash rendering)
    - [NgxBlurhashRender](https://www.npmjs.com/package/react-lazy-load-image-component)
  
- **Backend**:
  - ASP.NET Core (.NET 6 or higher)
  - C#
  - [SixLabors.ImageSharp](https://www.nuget.org/packages/SixLabors.ImageSharp/)
  - [Blurhash .NET Encoder](https://github.com/MarkusPalcer/blurhash.net)
  - Entity Framework Core (optional for tracking uploads in database)
  - Azure blob storage (optional for image storage)

## Installation

### Prerequisites

- .NET SDK (>= .NET 6)
- Node.js (>= v14)
- npm or yarn
- Angular CLI (if using Angular)

### Clone the Repository

```bash
git clone https://github.com/NiiAnyetei/BlurhashDemo.git
cd BlurhashDemo
```

### Install Dependencies

#### Backend

```bash
cd backend/BlurHash/BlurHash
dotnet restore
```

#### React Frontend

```bash
cd frontend/blurhash-react-project
npm install
```

#### Angular Frontend

```bash
cd frontend/blurhash-angular-project
npm install
```

## Usage

### Backend (ASP.NET Core)

1. Navigate to the `backend` directory and run the backend server:

```bash
cd backend/BlurHash/BlurHash
dotnet run --urls=http://localhost:5001/
```

The backend will start on `https://localhost:5001/` add /swagger to the localhost url (e.g https://localhost:5001/swagger).

### React Frontend

1. Navigate to the `blurhash-react-project` directory and start the React development server:

```bash
cd frontend/blurhash-angular-project
npm run dev -- --open --port 3000
```

The React frontend will be served at `http://localhost:3000`.

### Angular Frontend

1. Navigate to the `blurhash-angular-project` directory and start the Angular development server:

```bash
cd frontend/blurhash-angular-project
ng serve -o
```

The Angular frontend will be served at `http://localhost:4200`.

## API Endpoints

### `POST /api/Images`

Uploads an image/multiple images and returns 200.

- **Request**: `multipart/form-data` containing the image file(s).
- **Response**: 200.

### `GET /api/Images`

Gets all images.

- **Params**: `Limit` Limit number of articles (default is 20). `Offset` Offset/skip number of articles (default is 0).

- **Response**:

```json
{
  "uploadedImages": [
    {
      "id": "45eb6e2a-76fd-4540-a29c-08dcbd312d77",
      "url": "http://127.0.0.1:10000/devstoreaccount1/blurhash/about-4.webp",
      "blurHash": "KHG+5dE10exu%NIo%1D%V@"
    }
  ],
  "uploadedImagesCount": 1
}
```

## Examples

1. Start the backend (`https://localhost:5001`).

2. Navigate to `https://localhost:5001/swagger`

![Watch the video](https://imgur.com/5s7iWdE.png)

3. Upload an image on swagger (`POST /api/Images`).
4. Run either the React (`http://localhost:3000`) or Angular (`http://localhost:4200`) frontend and see the Blurhash placeholder displayed while the image loads.

React

![Watch the video](https://imgur.com/htAiqQc.gif)

Angular

![Watch the video](https://imgur.com/UqX1MEW.gif)
## 
