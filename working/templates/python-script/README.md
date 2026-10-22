# $SCRIPTNAME$

Python scripted integration for a DataMiner connector.

Script ID: `4f0bc4d6-7b21-48ee-9abc-4ce4be94b757`

Entry point: `run/main.py`

## Prerequisites

Install the latest Python 3.14 patch release before creating the virtual
environment. You can find the available releases on the
[Python downloads](https://www.python.org/downloads/) page. Do not install
Python 3.15 for this project; the connector runtime only supports Python 3.14.

## Development

1. Expand **Python Environments**. Do not generate requirements from the
   initially selected global Python environment; its packages are not project
   dependencies.
2. Add a project-local virtual environment named `.venv` using Python 3.14
   x64 and set it as current.
3. Right-click `.venv` and select **Install from requirements.txt**.

   Alternatively, install the dependencies from a terminal:

   `.\.venv\Scripts\python.exe -m pip install -r requirements.txt`

4. When dependencies change, install only the packages required by the
   project and use **Generate requirements.txt** > **Replace entire file** on
   `.venv`.
5. Set the `EDGE_RUN_SECRET` environment variable and run `run\main.py` with
   the project root as the working directory. Never store secrets in the
   project Debug arguments because they are committed to Git.
6. Run tests with:

   ```powershell
   .\.venv\Scripts\python.exe -m unittest discover -s tests -t . -p "test*.py" -v
   ```

The project root contains the runtime files copied into the packaged
`.dmprotocol\Scripts\4f0bc4d6-7b21-48ee-9abc-4ce4be94b757` directory.
Packaging adds resolved dependencies and excludes the `.pyproj`, tests,
`.venv`, caches, and other development files.

## Script structure

The entry point deliberately follows three steps:

1. `parse_input()` parses the inputs supplied by the runtime. Add the
   arguments required by your connector.
2. `get_data()` contains the connector-specific logic. Replace its example
   implementation with the code that retrieves and returns your data.
3. `push_data_to_edge_node()` sends that data to the Edge Node.

Keep the returned data JSON-serializable. The template separates the
connector-specific `get_data()` implementation from the provided push logic
so developers can focus on retrieving their data.
