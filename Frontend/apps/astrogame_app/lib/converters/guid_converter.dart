import 'package:flutter_guid/flutter_guid.dart';
import 'package:json_annotation/json_annotation.dart';

class GuidConverter implements JsonConverter<Guid, String> {
  const GuidConverter();

  @override
  Guid fromJson(String json) {
    return Guid(json);
  }

  @override
  String toJson(Guid object) {
    return object.toString();
  }
}
