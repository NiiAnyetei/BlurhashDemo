import React from "react";
import { useState } from "react";
import { Blurhash } from "react-blurhash";
import { LazyLoadImage } from "react-lazy-load-image-component";
import styled from "styled-components";
import { UploadedImage } from "../models";

const ImageWrapper = styled.div`
  position: relative;
`;

const StyledBlurhash = styled(Blurhash)`
  z-index: 20;
  position: absolute !important;
  top: 0;
  left: 0;
  border-raduis: 12px;
`;

interface IOptimizedImageProps {
    image: UploadedImage
}

function OptimizedImage(props: IOptimizedImageProps) {
    const { image } = props;

    const [isLoaded, setLoaded] = useState(false);
    const [isLoadStarted, setLoadStarted] = useState(false);

    const handleLoad = () => {
        setTimeout(() => {
            setLoaded(true);
        }, 2000);
    };

    const handleLoadStarted = () => {
        console.log("Started: ");
        setLoadStarted(true);
    };

    return (
        <ImageWrapper>
            <LazyLoadImage
                className="transition-all ease-in duration-1000 !rounded-xl"
                key={image.id}
                src={image.url}
                width="100%"
                // width={333}
                // height={500}
                onLoad={handleLoad}
                beforeLoad={handleLoadStarted}
            />
            {!isLoaded && isLoadStarted && (
                <StyledBlurhash
                    className="transition-all ease-out duration-1000 rounded-xl"
                    hash={image.blurHash}
                    // width={333}
                    // height={500}
                    width="100%"
                    height="100%"
                    resolutionX={32}
                    resolutionY={32}
                    punch={1}
                />
            )}
        </ImageWrapper>
    );
}

export { OptimizedImage };