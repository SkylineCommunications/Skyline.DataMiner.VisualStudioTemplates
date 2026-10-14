import json
import unittest
from pathlib import Path
from unittest.mock import patch
from uuid import UUID

from run.main import get_data, main, parse_input, push_data_to_edge_node


PROJECT_ROOT = Path(__file__).resolve().parents[1]
MANIFEST_PATH = PROJECT_ROOT / "manifest.json"


class ManifestTests(unittest.TestCase):
    def test_manifest_identity_and_entry_point(self):
        manifest = json.loads(MANIFEST_PATH.read_text(encoding="utf-8"))
        script_id = manifest["project"]["id"]

        self.assertEqual(script_id, str(UUID(script_id)))
        self.assertEqual("$SCRIPTNAME$", manifest["project"]["name"])
        self.assertEqual(
            "run/main.py",
            manifest["runtime"]["python"]["entry_point"],
        )


class MainTests(unittest.TestCase):
    def test_parse_input(self):
        input_data = parse_input([])

        self.assertEqual({}, vars(input_data))

    def test_get_data_returns_json_serializable_data(self):
        input_data = parse_input([])

        self.assertEqual({}, get_data(input_data))

    @patch("run.main.requests.post")
    def test_push_data_to_edge_node(self, mock_post):
        with patch.dict(
            "os.environ",
            {"EDGE_RUN_SECRET": "test-secret"},
            clear=True,
        ):
            response = push_data_to_edge_node({})

        mock_post.assert_called_once_with(
            "http://localhost:5016/api/data",
            json={},
            headers={"runSecret": "test-secret"},
            timeout=30,
        )
        mock_post.return_value.raise_for_status.assert_called_once_with()
        self.assertIs(mock_post.return_value, response)

    def test_push_requires_run_secret(self):
        with self.assertRaisesRegex(
            ValueError,
            "Required environment variable 'EDGE_RUN_SECRET' is missing",
        ):
            with patch.dict("os.environ", {}, clear=True):
                push_data_to_edge_node({})

    @patch("run.main.push_data_to_edge_node")
    @patch("run.main.get_data")
    def test_main_gets_and_pushes_data(self, mock_get_data, mock_push_data):
        data = {}
        mock_get_data.return_value = data

        with patch("sys.argv", ["main.py"]):
            main()

        mock_get_data.assert_called_once()
        mock_push_data.assert_called_once_with(data)


if __name__ == "__main__":
    unittest.main()
