import React from 'react';
import { useEffect } from 'react'
import './App.css'
import axios from 'axios'
import { useState } from 'react';
import { OptimizedImage } from './components/optimizedImage';
import { ApiData } from './models';

const apiUrl = "https://localhost:7273/api/Images";

function App() {
  const [apiData, setApiData] = useState<ApiData | null>(null);

  useEffect(() => {

    const fetchData = async () => {
      try {
        const response = await axios.get<ApiData>(apiUrl);
        setApiData(response.data);
      } catch (error) {
        console.error('Error fetching data:', error);
      }
    };

    fetchData();
  }, [])

  return (
    <>
      {apiData ? (
        <div className="columns-2 md:columns-4 gap-4 space-y-4 p-4">
          {apiData.uploadedImages.map((item) => (
            <div key={item.id}>
              <OptimizedImage image={item} />
            </div>
          ))}
        </div>
      ) : (
        <div className="flex items-center justify-center text-center text-lg">Loading...</div>
      )}
    </>
  )
}

export default App
