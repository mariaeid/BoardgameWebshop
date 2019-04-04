import React from "react";
import PropTypes from "prop-types";

const Title = props => {

  return (
    <div>
      <h1> {props.title} </h1>
    </div>
  )
}

Title.propTypes = {
  title: PropTypes.string,
};

export default Title;
