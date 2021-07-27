import 'package:astrogame_app/communications/converters/guid_converter.dart';
import 'package:astrogame_app/models/resources/resource.dart';
import 'package:astrogame_app/models/resources/stellar_object_resource.dart';
import 'package:json_annotation/json_annotation.dart';
import 'element_type.dart';

part 'element.g.dart';

@GuidConverter()
@JsonSerializable()
class Element extends Resource {
  @JsonKey()
  late String symbol;

  @JsonKey()
  late ElementType type;

  Element();

  factory Element.fromJson(Map<String, dynamic> json) =>
      _$ElementFromJson(json);
  Map<String, dynamic> toJson() => _$ElementToJson(this);
}
