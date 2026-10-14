import argparse
import os

import requests


def parse_input(arguments=None):
    parser = argparse.ArgumentParser()
    # Add the input arguments required by your connector.
    return parser.parse_args(arguments)


def get_data(input_data):
    """Collect and return the JSON-serializable data for this connector."""
    # Replace this example with the logic that retrieves your connector data.
    return {}


def push_data_to_edge_node(data):
    """Push connector data to the local Edge Node API."""
    run_secret = os.getenv("EDGE_RUN_SECRET")
    if not run_secret:
        raise ValueError(
            "Required environment variable 'EDGE_RUN_SECRET' is missing"
        )

    response = requests.post(
        "http://localhost:5016/api/data",
        json=data,
        headers={"runSecret": run_secret},
        timeout=30,
    )
    response.raise_for_status()
    return response


def main():
    input_data = parse_input()
    data = get_data(input_data)
    push_data_to_edge_node(data)


if __name__ == "__main__":
    main()
