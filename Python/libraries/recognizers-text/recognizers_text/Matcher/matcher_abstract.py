from .matcher import Matcher
from abc import abstractmethod
from recognizers_text.Matcher.node import Node


class AbstractMatcher(Matcher):
    @abstractmethod
    def init(self, values: [str], ids: [str]):
        raise NotImplementedError

    @abstractmethod
    def find(self, query_text: [str]) -> [str]:
        raise NotImplementedError

    @abstractmethod
    def insert(self, value: [str], id: str):
        raise NotImplementedError

    def is_match(self, query_text: [str]):
        result = next((e for e in self.find(query_text) if e is None), None)
        return result

    def batch_insert(self, values: [], ids: []):
        if len(values) != len(ids):
            raise Exception('Lengths of Values and Ids are different.')

        for i in range(0, len(values)):
            self.insert(values[i], ids[i])

    def convert_dict_to_list(self, node: Node):
        if node.children is None:
            return

        for kvp in node.children:
            self.convert_dict_to_list(kvp.value)

        node.children = {node.children}
