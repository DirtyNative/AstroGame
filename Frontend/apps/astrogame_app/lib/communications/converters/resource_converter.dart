import 'package:astrogame_app/models/resources/element.dart';
import 'package:astrogame_app/models/resources/material.dart';
import 'package:astrogame_app/models/resources/resource.dart';
import 'package:json_annotation/json_annotation.dart';

class ResourceConverter
    implements JsonConverter<Resource, Map<String, dynamic>> {
  const ResourceConverter();

  @override
  fromJson(json) {
    if (json.containsKey('\$type') == false) {
      throw Exception('json does not contain type key');
    }

    //var type = json['\$type'];
    var type = json.entries.firstWhere((element) => element.key == '\$type');

    if (type.value == 'Material') {
      return Material.fromJson(json);
    } else if (type.value == 'Element') {
      return Element.fromJson(json);
    }

    throw new UnimplementedError('Resource is not yet implemented');
  }

  @override
  toJson(object) {
    throw UnimplementedError();
  }
}
