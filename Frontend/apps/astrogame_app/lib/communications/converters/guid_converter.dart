import 'package:astrogame_app/models/common/guid.dart';
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

class NullableGuidConverter implements JsonConverter<Guid?, String> {
  const NullableGuidConverter();

  @override
  Guid? fromJson(String json) {
    return Guid(json);
  }

  @override
  String toJson(Guid? object) {
    return object.toString();
  }
}
